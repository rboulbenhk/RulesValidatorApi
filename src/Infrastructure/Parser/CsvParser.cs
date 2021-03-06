namespace RulesValidatorApi.Infrastructure.Parser;
public class CsvParser : IDisposable
{
    private readonly StreamReader _streamReader;
    private readonly string[] _header;

    public CsvParser(Stream stream) : this(new StreamReader(stream))
    {

    }
    public CsvParser(StreamReader streamReader)
    {
        _streamReader = streamReader;
        _header = ReadHeader();
        if (_header.Length == 0 || _header.Any(string.IsNullOrWhiteSpace))
        {
            throw new ParsingException("No header found in the file");
        }
    }

    public IAsyncEnumerable<CsvRow> Read()
    {
        async IAsyncEnumerable<CsvRow> InnerRead()
        {
            var rowNumber = 1;
            while (!_streamReader.EndOfStream)
            {
                string? line = await _streamReader.ReadLineAsync();
                yield return new CsvRow(_header, line ?? string.Empty, ++rowNumber);
            }
        }
        return InnerRead();
    }

    private string[] ReadHeader() => _streamReader.ReadLine()?.Split() ?? Array.Empty<string>();
    
    //TODO implement
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}