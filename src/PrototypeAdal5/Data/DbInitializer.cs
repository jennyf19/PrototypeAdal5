using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrototypeAdal5.Models;

namespace PrototypeAdal5.Data
{
    public class DbInitializer
    {
        public static void Initialize(ReleaseContext context)
        {
            context.Database.EnsureCreated();

            //Look for any releases
            if (context.Releases.Any())
            {
                return;
            }

            var releases = new Release[]
            {
                new Release
                {
                    ProductName = "Adal-v4",
                    VersionNumber = "v1.11.11",
                    ReleaseNotes = "Cats are amazing",
                    SubmissionDate = DateTime.Parse("2016-12-02"),
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Aashima",
                    ApprovedDate = DateTime.Parse("2016-12-08")
                },
                new Release
                {
                    ProductName = "Msal-DotNet",
                    VersionNumber = "v2.00.01",
                    ReleaseNotes = "Cats are love to climb, nap, hunt, and groom",
                    SubmissionDate = DateTime.Parse("2016-09-12"),
                    ApprovalStatus = ApprovalStatus.Pending,
                    ApprovedBy = "Aashima",
                    ApprovedDate = DateTime.Parse("2016-10-02")
                },

                new Release
                {
                    ProductName = "Azure-Active-Directory",
                    VersionNumber = "v1.23.01",
                    ReleaseNotes = "Long haired cats are misunderstood",
                    SubmissionDate = DateTime.Parse("2014-09-03"),
                    ApprovalStatus = ApprovalStatus.Denied,
                    ApprovedBy = "Rich",
                    ApprovedDate = DateTime.Parse("2014-10-02")
                },

                new Release
                {
                    ProductName = "Build-Android-Master",
                    VersionNumber = "v1.94.21",
                    ReleaseNotes = "Cats and unicorns rule the multiverse",
                    SubmissionDate = DateTime.Parse("2012-08-12"),
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Rich",
                    ApprovedDate = DateTime.Parse("2012-10-18")
                },
            };
            foreach (Release r in releases)
            {
                context.Releases.Add(r);
            }
            context.SaveChanges();
        }
    }
}



