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
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus env:deploy qubytest.dev --sync-content --note="From Jenkins" --cc

'''
        input(message: 'Validate site', id: '1', ok: 'Ok', submitter: 'Designer', submitterParameter: 'w')
      }
    }
    stage('Test Deployment') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus env:deploy qubytest.test --note="To Test by Jenkins" --cc'''
        input 'Validate test site'
      }
    }
    stage('Live deployment') {
      steps {
        sh '''alias terminus=/home/bitnami/terminus/vendor/bin/terminus
terminus env:deploy qubytest.live --note="To Live by Jenkins" --cc'''
        input 'All set for live'
      }
    }
  }
}