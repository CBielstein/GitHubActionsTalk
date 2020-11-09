dotnet publish --configuration Release --runtime centos.8-x64 --no-self-contained -o published src/Hello/Hello.csproj

# Stop current service
ssh $USER_HOST systemctl stop helloapp

# Place systemd unit file
scp -Cp deploy/helloapp.service $USER_HOST:/etc/systemd/system/helloapp.service

# rsync to copy files
rsync -az --delete -e ssh published/ $USER_HOST:/web/hello

# Resume service
ssh $USER_HOST systemctl daemon-reload
ssh $USER_HOST systemctl enable helloapp
ssh $USER_HOST systemctl start helloapp
