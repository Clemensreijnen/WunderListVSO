pipeline {
  agent any
  stages {
    stage('Pre Build') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus -V
terminus auth:login --machine-token=PDw-MCyX3vJI2UG1_qwrIPJ1cbvlXTseUvWm2RuonIQH5'''
        sh '''curl -H "Content-Type:text/xml" -X POST -d '<TargetServer name="D2C">
   <Host>sogeti-api-admin-assess-d.azurewebsites.net</Host>
   <Port>80</Port>
   <IsEnabled>true</IsEnabled>
 </TargetServer>' -u ${apigee_usermail}:${apigee_password} https://api.enterprise.apigee.com/v1/o/${apigee_instance}/environments/dev/targetservers
'''
        sh '''
npm config set prefix '~/.npm-global'
export PATH=~/.npm-global/bin:$PATH
 
npm install -g cypress-cli'''
      }
    }
    stage('Develop Deployment') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus upstream:updates:list qubytest
'''
        sh 'npm install -g cypress-cli'
      }
    }
    stage('Test Deployment') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus env:deploy qubytest.test --note="To Test by Jenkins" --cc'''
      }
    }
    stage('Live deployment') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus env:deploy qubytest.live --note="To Live by Jenkins" --cc'''
      }
    }
  }
}