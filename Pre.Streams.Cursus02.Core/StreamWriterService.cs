using System.Text;

namespace Pre.Streams.Cursus02.Core;

public class StreamWriterService
{
    public bool WriteStringToFile(string content, string path, string fileName, Encoding encoding = null,
        bool overWrite = false)
    {
        bool successfull = false;
        if (encoding == null) encoding = Encoding.Default;
        if (!Directory.Exists(path))
            throw new Exception($"Het opgegeven pad {path} bestaat niet!");
        string fullPath = path + "\\" + fileName;

        VerifyFileWritingConditions(path, fileName, overWrite, fullPath);

        try
        {
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, encoding))
                {
                    streamWriter.Write(content);
                }
            }

            successfull = true;
        }
        catch (Exception e)
        {
            throw new Exception($"Er is een fout opgetreden. {e.Message}");
        }

        return successfull;
    }

    private void VerifyFileWritingConditions(string path, string fileName, bool overWrite, string fullPath)
    {
        if (!overWrite)
        {
            if (File.Exists(fullPath))
                throw new Exception(
                    $"De bestandsnaam {fileName} is in de map {path} reeds in gebruik.\nGebruik de knop Overschrijf bestand");
        }
        else
        {
            DeleteFile(path, fileName, fullPath);
        }
    }

    private void DeleteFile(string path, string fileName, string fullPath)
    {
        try
        {
            File.Delete(fullPath);
        }
        catch
        {
            throw new Exception(
                $"De bestandsnaam {fileName} in de map {path} is momenteel in gebruik.\nProbeer later opnieuw");
        }
    }
}