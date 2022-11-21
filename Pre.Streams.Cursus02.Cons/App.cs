using Pre.Streams.Cursus02.Core;

namespace Pre.Streams.Cursus02.Cons;

public class App
{
    private UserIO _userIo;
    private string _assetPath = @"../../../Assets/";

    public App()
    {
        _userIo = new UserIO();
    }

    public void Run()
    {
        StreamReaderService streamReaderService = new StreamReaderService();
        EncodingService encodingService = new EncodingService();
        var availableCharSets = encodingService.AvailableCharSets;
        var filesInAssets = GetFilesInAssets();

        string fileName = filesInAssets.First();
        EncodingEntity encodingEntity = (EncodingEntity)availableCharSets.First();
        DirectoryInfo di = new DirectoryInfo(_assetPath);

        try
        {
            string message = streamReaderService.ReadFileToString(di.FullName, fileName, encodingEntity.CharacterSet);
            ShowFeedback($"Bestand {fileName} werd succesvol gelezen", true);

            _userIo.DisplayPrompt(message);
        }
        catch (Exception ex)
        {
            ShowFeedback(ex.Message);
        }
    }

    private void ShowFeedback(string message, bool isSucces = false)
    {
        if (isSucces)
        {
            _userIo.SetColor(ConsoleColor.Green);
        }
        else
        {
            _userIo.SetColor(ConsoleColor.Red);
        }


        _userIo.DisplayPrompt(message);
        _userIo.ResetColor();
    }

    private IEnumerable<string> GetFilesInAssets()
    {
        DirectoryInfo di = new DirectoryInfo(_assetPath);
        foreach (FileInfo fi in di.GetFiles())
        {
            yield return fi.Name;
        }
    }
}