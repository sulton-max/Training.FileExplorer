using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using AutoMapper;
using Training.FileExplorer.Application.FileStorage.Brokers;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    private readonly IMapper _mapper;

    public DirectoryBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath) => Directory.EnumerateDirectories(directoryPath);

    public IEnumerable<string> GetFilesPath(string directoryPath) => Directory.EnumerateFiles(directoryPath);

    public StorageDirectory GetByPathAsync(string directoryPath) => _mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath));

    public bool ExistsAsync(string directoryPath) => Directory.Exists(directoryPath);

    public bool SetAccessControl(string directoryPath)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return false;

        var directoryInfo = new DirectoryInfo(directoryPath);
        var directorySecurity = directoryInfo.GetAccessControl();

        // var test = directorySecurity.AreAccessRulesProtected;
        //
        // directorySecurity.AddAccessRule(new FileSystemAccessRule(System.Security.Principal.WindowsIdentity.GetCurrent().Name,
        //     FileSystemRights.FullControl,
        //     InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
        //     PropagationFlags.None,
        //     AccessControlType.Allow));

        var currentUser = Environment.UserDomainName + "\\" + Environment.UserName;
        var rule = new FileSystemAccessRule(
            new NTAccount(currentUser),
            FileSystemRights.ReadData,
            AccessControlType.Allow);

        // Add the rule to the directory's access control list
        directorySecurity.AddAccessRule(rule);

        // Set the new access control list for the directory
        directoryInfo.SetAccessControl(directorySecurity);

        return true;
    }

    // public bool IsAccessible(string directoryPath)
    // {
    //     var directorySecurity = new DirectoryInfo(directoryPath).GetAccessControl();
    //
    //     return directorySecurity.AreAccessRulesProtected;
    // }
}