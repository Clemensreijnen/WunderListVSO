pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        echo 'Building..'
        echo 'UnitTesting ...'
        sh '''
cd /home/bitnami/terminus/vendor/bin
terminus -V'''
      }
    }
    stage('Import in Apigee') {
      steps {
        parallel(
          "Apigee": {
            echo 'Importing ....'
            echo 'Create Apigee Targets'
            sh 'curl -O https://raw.githubusercontent.com/pantheon-systems/terminus-installer/master/builds/installer.phar && php installer.phar install'
            
          },
          "Create Apigee model": {
            echo 'Set developerpotral'
            
          }
        )
      }
    }
    stage('Develop Deployment') {
      steps {
        echo 'Deploy to container'
        echo 'API Test deployment'
        echo 'Deploy to Apigee develop'
        echo 'Api Testing on Apigee endpoints'
      }
    }
    stage('Test Deployment') {
      steps {
        echo 'Deploy test'
        echo 'Deploy test Apigee'
        echo 'Api test'
        echo 'Configure monitoring'
      }
    }
    stage('Staging deployment') {
      steps {
        echo 'Deploying staging'
        echo 'Deploying staging Apigee'
        echo 'Api testing ...'
        echo 'Configure monitoring'
      }
    }
    stage('Production deployment') {
      steps {
        echo 'deploying '
        echo 'Deploy Prod Apigee'
        echo 'Api testing '
        echo 'Configure monitoring'
      }
    }
  }
}