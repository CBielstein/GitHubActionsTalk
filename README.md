# GitHubActionsTalk
Code to accompany a conference talk on an intro to GitHub Actions.

## Deployment

1. Install [ASP.NET Core Runtime 3.1 for Linux](https://dotnet.microsoft.com/download/dotnet-core/3.1)
1. Configure firewall to allow access to 80/tcp (CentOS8 commands below)
    * `sudo firewall-cmd --zone=public --add-port 80/tcp --permanent`
    * `sudo firewall-cmd --reload`
1. `export USER_HOST=$USER@$HOST` (`$USER` e.g. `root` and `$HOST` being domain name or IP address of the host machine)
1. run `deploy/deploy.sh`
