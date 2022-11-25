# Requirements

## Functional Requirements

- Given a path to a local repository, the application should collect all commits with respective author names and author dates.
- The program should be able to run in two modes, namely commit frequency mode and commit author mode, which may be indicated via command-line switches.
- When running GitInsight in commit frequency mode, it should produce textual output on stdout that lists the number of commits per day.
- When running GitInsight in commit author mode, it should produce textual output on stdout that lists the number of commits per day per author.
- In case a Git repository is re-analyzed, i.e., your database contains already results from a previous analysis, then the stored data has to be updated to the most current analysis results.
- In case a Git repository is re-analyzed for which you already have analysis results that correspond to the most current state of the repository, then the analysis step should be skipped entirely and the output should be generated from the readily available data directly.

## Non-Functional Requirements

- The program has to store information about which repositories were analyzed at which state.
