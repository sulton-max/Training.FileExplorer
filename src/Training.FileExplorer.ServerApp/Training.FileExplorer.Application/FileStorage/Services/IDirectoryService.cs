﻿using Training.FileExplorer.Application.FileStorage.Models;
using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDirectoryService
{
    ValueTask<IList<StorageDirectory>> GetSubDirectoriesAsync(string directoryPath);

    ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath);
}