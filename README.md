# Employee-App
Simple Web App with API runs in Docker and kubernetes

clone code.
do docker compose up -- to build and run in docker.

and 

`kubectl apply -f /kubernetes`

this will create /deployments and service in k8

try in http://locahost  -> this will launch the webapp.

create an employee record and will list all the employees.

shutdown k8 

`kubectl delete -f /kubernetes`
