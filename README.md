# README

This README would normally document whatever steps are necessary to get your application up and running.

### What is this repository for?

This repository contains the code to compress the archive log.
It is generic so it can compress any folder.
Steps to compress:

1. There is configuration setup in json file that contains details to compress folder.
2. It move the files from source to destination directory based on the size of source directory which is configurable.
3. If size is equal or greater than configurable size, Then it creates a directory with timestamp in destination directory.
4. Then it moves all contents of source directory to timestamp destination directory.
5. Then it compress the timestamp directory
6. Finally, deletes the the timestamp directory.

### How do I get set up?

- Summary of set up
- Configuration
- Dependencies
  It depepends on System.IO.Compression
  and System.IO.Compression.FileSystem
- Database configuration
  There is no Database configuration this application.
- How to run tests
  There is no testcase for this application.
- Deployment instructions
  1.  Open the solution in Visual Studio, build the solution in release mode.
  2.  Go to the Melissa.ArchiveLog\Melissa.ArchiveLog\bin\Release folder.
  3.  Paste the JobSchedulerConfig.json file to Melissa.ArchiveLog\Melissa.ArchiveLog\bin\Release.
  4.  Finally, Copy all the artifacts from Melissa.ArchiveLog\Melissa.ArchiveLog\bin\Release folder and deployed the application.

### Contribution guidelines

- Writing tests
  No testcase
- Code review
  Amit Pandey, Vikas Tomar
- Other guidelines

### Who do I talk to?

- Repo owner or admin
- Other community or team contact
  Melissa Dev Team
