# Stop current service
ssh -l $DEPLOY_USER $DEPLOY_HOST systemctl stop helloapp

# Place systemd unit file
scp -Cp deploy/helloapp.service $DEPLOY_USER@$DEPLOY_HOST:/etc/systemd/system/helloapp.service

# rsync to copy files
rsync -az --delete -e ssh $1 $DEPLOY_USER@$DEPLOY_HOST:/web/hello

# Start/resume service
ssh -l $DEPLOY_USER $DEPLOY_HOST systemctl daemon-reload
ssh -l $DEPLOY_USER $DEPLOY_HOST systemctl enable helloapp
ssh -l $DEPLOY_USER $DEPLOY_HOST systemctl start helloapp
