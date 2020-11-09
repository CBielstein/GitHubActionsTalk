# Stop current service
ssh $USER_HOST systemctl stop helloapp

# Place systemd unit file
scp -Cp deploy/helloapp.service $USER_HOST:/etc/systemd/system/helloapp.service

# rsync to copy files
rsync -az --delete -e ssh $1 $USER_HOST:/web/hello

# Start/resume service
ssh $USER_HOST systemctl daemon-reload
ssh $USER_HOST systemctl enable helloapp
ssh $USER_HOST systemctl start helloapp
