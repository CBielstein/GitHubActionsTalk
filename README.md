# GitHubActionsTalk

Demo code for a [talk on GitHub Actions](https://osem.seagl.org/conferences/seagl2020/program/proposals/769) delivered at [SeaGL](https://seagl.org) 2020.

## Deployment

### Host Setup

1. Install [ASP.NET Core Runtime 3.1 for Linux](https://dotnet.microsoft.com/download/dotnet-core/3.1)
1. Install rsync: (`sudo yum install -y rsync` in CentOS8)
1. Configure firewall to allow access to 80/tcp (CentOS8 commands below)
    * `sudo firewall-cmd --zone=public --add-port 80/tcp --permanent`
    * `sudo firewall-cmd --reload`

### Code Deployment

1. Build and publish to the `published/` directory: `dotnet publish --configuration Release --runtime centos.8-x64 --no-self-contained -o published src/Hello/Hello.csproj`
1. `export USER_HOST=$USER@$HOST` (`$USER` e.g. `root` and `$HOST` being domain name or IP address of the host machine)
1. Deploy from the `published/` directory: `deploy/deploy.sh published` (assumes SSH keys are configured)
