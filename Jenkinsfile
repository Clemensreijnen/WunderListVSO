pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        parallel(
          "Build": {
            echo 'Building..'
            
          },
          "": {
            mail(subject: 'from jenkins', body: 'hello', from: 'clemens@al77.nl', replyTo: 'clemens@al77.nl', to: 'clemens@al77.nl')
            
          }
        )
      }
    }
    stage('Test') {
      steps {
        echo 'Testing..'
      }
    }
    stage('Deploy') {
      steps {
        echo 'Deploying....'
      }
    }
  }
}