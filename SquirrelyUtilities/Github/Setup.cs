using System;
using System.Threading.Tasks;
using Octokit;
// ReSharper disable AssignmentIsFullyDiscarded

namespace SquirrelyUtilities.Github {
    public class Setup {
        private static readonly Lazy<Setup> SetupLazy = new Lazy<Setup>(() => new Setup());
        public static Setup Instance => SetupLazy.Value;

        private readonly GitHubClient _gitHubClient;
        private readonly Credentials _credentials = new Credentials(GToken.GetToken);

        public Setup() => _gitHubClient = new GitHubClient(new ProductHeaderValue("Squirrely-Utilities-Bug-and-Features")) { Credentials = _credentials };

        public void SubmitBug(string title, string body, string tag) {
            NewIssue issue = new NewIssue(title) { Body = body };
            issue.Labels.Add("bug");
            issue.Labels.Add(tag);
            _ = SubmitIssue(issue);
        }

        public void SubmitFeature(string title, string body, string tag) {
            NewIssue issue = new NewIssue(title) { Body = body };
            issue.Labels.Add("enhancement");
            issue.Labels.Add(tag);
            _ = SubmitIssue(issue);
        }

        public async Task SubmitIssue(NewIssue issue) => await _gitHubClient.Issue.Create("MrSquirrely", "SquirrelyUtilities", issue);
    }
}
