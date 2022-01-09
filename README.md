# Employee-App
Simple Web App with API runs in Docker and kubernetes

clone code.
do docker compose up -- to build and run in docker.

and 

`kubectl apply -f /kubernetes`

this will create /deployments and service in k8

try in http://localhost  -> this will launch the webapp.

create an employee record and will list all the employees.

test empapi via post man

do a port forward for the api pod
 `kubectl get pods`
 
 `kubectl port-forward empapi-5ccd6f876c-258rz 8504:80`

note : empapi-5ccd6f876c-258rz 8504:80 is mypod #, it could be different each time

using postman, try the API

`GET  http://localhost:8504/api/employee`  -- will list all the employee

shutdown k8 

`kubectl delete -f /kubernetes`
