pipeline {
  agent any
  stages {
    stage('Pre Build') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus -V
terminus auth:login --machine-token=PDw-MCyX3vJI2UG1_qwrIPJ1cbvlXTseUvWm2RuonIQH5'''
        sh '''sh' alias cypress=/home/bitnami/'
sh 'cypress npm install -g cypress-cli'
dir '/home/bitnami/'



'''
      }
    }
    stage('Develop Deployment') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus upstream:updates:list qubytest
'''
        input(message: 'Proceed deployment to Test?', id: 'ProceedtoTest')
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