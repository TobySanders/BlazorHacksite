﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Abstractions.Models
{
    public class ProjectTableEntity : TableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public string ProjectImage { get; set; }
        public string ShortCode { get; set; }
        public bool IsActive { get; set; }


        public ProjectTableEntity(Project project)
        {
            Id = project.Id == Guid.Empty ? Guid.NewGuid() : project.Id;
            Title = project.Title;
            Description = project.Description;
            RepositoryUrl = project.RepositoryUrl;
            ProjectImage = project.ProjectImage;
            ShortCode = project.ShortCode;
            IsActive = project.IsActive;

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        public ProjectTableEntity(Guid id)
        {
            Id = Id;

            PartitionKey = "0";
            RowKey = Id.ToString();
        }
    }
}
