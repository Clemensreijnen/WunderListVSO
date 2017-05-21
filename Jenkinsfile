pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        echo 'Building..'
        echo 'UnitTesting ...'
      }
    }
    stage('Package') {
      steps {
        echo 'Packaging..'
        echo 'Set in artifactory'
      }
    }
    stage('Import in Apigee') {
      steps {
        parallel(
          "Import in Apigee": {
            echo 'Importing ....'
            echo 'Create Apigee Targets'
            
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