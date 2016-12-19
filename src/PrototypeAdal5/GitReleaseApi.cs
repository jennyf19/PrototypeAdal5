using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PrototypeAdal5
{
    public class GitReleaseApi
    {
        //Json response properties for GitHub api latest release request
        //https://api.github.com/repos/:owner/:repo/releases/latest
        public class Author
        {
            public string login { get; set; }
            public int id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        [DataContract]
        public class GitHubRepoLatestRelease
        {
            [DataMember]
            public string url { get; set; }
            [DataMember]
            public string assets_url { get; set; }
            [DataMember]
            public string upload_url { get; set; }
            [DataMember]
            public string html_url { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string tag_name { get; set; }
            [DataMember]
            public string target_commitish { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public bool draft { get; set; }
            [DataMember]
            public Author author { get; set; }
            [DataMember]
            public bool prerelease { get; set; }
            [DataMember]
            public string created_at { get; set; }
            [DataMember]
            public string published_at { get; set; }
            [DataMember]
            public List<object> assets { get; set; }
            [DataMember]
            public string tarball_url { get; set; }
            [DataMember]
            public string zipball_url { get; set; }
            [DataMember]
            public string body { get; set; }
        }
    }
}
