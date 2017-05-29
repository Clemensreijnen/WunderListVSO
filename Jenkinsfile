pipeline {
  agent any
  stages {
    stage('Pre Build') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus -V
terminus auth:login --machine-token=PDw-MCyX3vJI2UG1_qwrIPJ1cbvlXTseUvWm2RuonIQH5'''
      }
    }
    stage('Develop Deployment') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus upstream:updates:list qubytest'''
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