# Stop current service
ssh $USER_HOST systemctl disable helloapp.service

# rsync to copy files
rsync -az --delete -e ssh src/Hello/bin/Release/netcoreapp3.1/centos.8-x64/publish/ root@45.33.53.88:/web/hello

# Resume service
ssh $USER_HOST systemctl enable helloapp.service
