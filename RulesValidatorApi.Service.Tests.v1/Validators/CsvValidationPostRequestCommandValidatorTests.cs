using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using AutoFixture;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RulesValidatorApi.Service.v1.Commands;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
using RulesValidatorApi.Service.v1.Rules;
using RulesValidatorApi.Service.v1.ValidatorsApi;
using RulesValidatorApi.Service.ValidatorsApi;

namespace RulesValidatorApi.Service.Tests.v1.Validators
{
    [TestFixture]
    public class CsvValidationPostRequestCommandValidatorTest
    {
        private CsvValidationPostRequestCommandValidator _csvValidationPostRequestCommandValidator = default!;
        private RuleSetOptions _ruleSetOptions = default!;
        private RuleSetOptions _ruleSetOptionsWithNoArguments = default!;
        private Mock<IOptionsMonitor<IEnumerable<RuleSetOptions>>> _ruleSetOptionsMock = default!;
        private Mock<IFileSystem> _fileSystem = default!;

        [OneTimeSetUp]
        public void SetUp()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;
            var fixture = new Fixture();
            _fileSystem = new Mock<IFileSystem>();
            _fileSystem.Setup(f => f.File.Exists(It.IsAny<string>())).Returns(true);
            _ruleSetOptions = fixture.Create<RuleSetOptions>();
            _ruleSetOptionsWithNoArguments = fixture.Create<RuleSetOptions>();
            _ruleSetOptionsWithNoArguments.PossibleArgumentValues = Enumerable.Empty<string>();
            _ruleSetOptionsWithNoArguments.ArgumentRegex = string.Empty;
            _ruleSetOptionsMock = new Mock<Microsoft.Extensions.Options.IOptionsMonitor<IEnumerable<RuleSetOptions>>>();
            _ruleSetOptionsMock.Setup(c => c.CurrentValue)
            .Returns(new RuleSetOptions[]
            {
                _ruleSetOptions,
                _ruleSetOptionsWithNoArguments
            });           
        }

        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheFilePathIsNull_ThenWeHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);
            result.ShouldHaveValidationErrorFor(r => r.FilePath);
        }
        
        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenThePathIsNotCorrect_ThenWeHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyFakeCsvFile.csv";
            var fileSystem = new Mock<IFileSystem>();
            fileSystem.Setup(f => f.File.Exists(model.FilePath)).Returns(false);
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,fileSystem.Object).TestValidate(model);
            var error = Errors.InvalidFilePath(model.FilePath);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain($"{error.code} {error.message}"));
        }

        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheFilePathIsNotACsvFile_ThenWeHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyFakeCsvFile.txt";
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);
            var error = Errors.InvalidFilePathExtension(Path.GetExtension(model.FilePath),model.FilePath);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain($"{error.code} {error.message}"));
        }

        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenThePathExists_ThenWeShouldNotHaveErrorOnThePath()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = @"CsvTestFiles\MyCsvTestFile.csv";
            var fileSystem = new Mock<IFileSystem>();
            fileSystem.Setup(f => f.File.Exists(model.FilePath)).Returns(true);
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,fileSystem.Object).TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(r => r.FilePath);
        }

        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheColumnIdIsEqualToZero_ThenWeShouldHaveError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyCsvTestFile.csv";
            model.RuleSet = new PostRuleSetRequest[]{ new PostRuleSetRequest{ColumnId = -1} };
            var ruleSetOptionsMock = new Mock<Microsoft.Extensions.Options.IOptionsMonitor<IEnumerable<RuleSetOptions>>>();
            ruleSetOptionsMock.Setup(c => c.CurrentValue)
            .Returns(new RuleSetOptions[]
            {
                _ruleSetOptionsWithNoArguments
            });
            var result = new CsvValidationPostRequestCommandValidator(ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);            
            var error = Errors.InvalidColumnId(model.RuleSet.First().ColumnId);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain($"{error.code} {error.message}"));
        }

        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheRuleSetAreEmpty_ThenWeShouldHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyCsvTestFile.csv";
            model.RuleSet = default!;
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);            
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain("'Rule Set' must not be empty."));
        }
        
        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheRuleNameIsEmpty_ThenWeShouldHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyCsvTestFile.csv";
            model.RuleSet = new PostRuleSetRequest[]{ new PostRuleSetRequest{ColumnId = 1, RuleName = string.Empty} };
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);            
            var error = Errors.InvalidRuleName(model.RuleSet.First().RuleName);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain($"{error.code} {error.message}"));
        }
        
        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheRuleNameDoesNotExists_ThenWeShouldHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyCsvTestFile.csv";
            model.RuleSet = new PostRuleSetRequest[]{ new PostRuleSetRequest{ColumnId = 1, RuleName = "MyFakeRuleName"} };
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);
            var error = Errors.InvalidRuleName(model.RuleSet.First().RuleName);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain($"{error.code} {error.message}"));
        }
        
        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheRuleNameWithMandatoryArgumentHasNoArgument_ThenWeShouldHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyCsvTestFile.csv";
            model.RuleSet = new PostRuleSetRequest[]{ new PostRuleSetRequest{ColumnId = 1, RuleName = _ruleSetOptions.RuleName, ArgumentValues = Enumerable.Empty<string>()} };
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);
            var error = Errors.MissingArguments(model.RuleSet.First().RuleName, _ruleSetOptions.PossibleArgumentValues);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain($"{error.code} {error.message}"));
        }
        
        [Test]
        public void GivenCsvValidationPostRequestCommandValidator_WhenTheRuleNameWithNoMandatoryArgumentHasAnArgument_ThenWeShouldHaveAnError()
        {
            var model = new CsvValidationPostRequestCommand();
            model.FilePath = "MyCsvTestFile.csv";
            model.RuleSet = new PostRuleSetRequest[]{ new PostRuleSetRequest{ColumnId = 1, RuleName = _ruleSetOptionsWithNoArguments.RuleName, ArgumentValues = new string[]{"MyFakeArguments"} }};
            var result = new CsvValidationPostRequestCommandValidator(_ruleSetOptionsMock.Object,_fileSystem.Object).TestValidate(model);
            var error = Errors.RuleSetHasNoArgument(_ruleSetOptionsWithNoArguments.RuleName, model.RuleSet.First().ArgumentValues);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Errors[0].ErrorMessage, Does.Contain($"{error.code} {error.message}"));
        }
    }
}
