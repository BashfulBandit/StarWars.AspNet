# StarWars.AspNet

Star Wars REST API in ASP.NET 6.0.

## Getting Started

### Prerequisites

- Install and start Docker: https://docs.docker.com/get-docker/

## Running in Docker

To simply deploy/run the Star Wars REST API via Docker, you can run the command:

```bash
$ docker run -p 8080:80 ghcr.io/bashfulbandit/starwars.aspnet.api:latest
```

## Running via `docker compose`

There is an example `docker-compose.yaml` file in the root of the repository.
This can be used to easily start up an instance of the `StarWars.AspNet.Api`.

```yaml
services:
  api:
    image: ghcr.io/bashfulbandit/starwars.aspnet.api:latest
    ports:
      - 8080:80
```

### API Endpoint for getting started and documentation

There is a Healthcheck API endpoint at `http://localhost:8080/api/healthz`.
There is also a Swagger UI available at `http://localhost:8080/api/swagger`.

The Swagger UI provides technical documentation for the API and an easy to use
interface for interacting with the various API endpoints.

## Coding Exercise API Endpoints

### `GET /api/characters/{characterId}/starships`

#1 - Return a list of the Starships related to Luke Skywalker

Luke Skywalker's `characterId` is `2`.

Query Parameters:

- `page` - Defaults to `1`.
- `pageSize` - Defaults to `25`.

```json
{
    "starships": [
        {
            "id": "12",
            "name": "X-wing",
            "model": "T-65 X-wing",
            "starshipClass": "Starfighter",
            "manufacturer": [
                "Incom Corporation"
            ],
            "costInCredits": "149999",
            "length": "12.5",
            "crew": "1",
            "passengers": "0",
            "maxAtmospheringSpeed": "1050",
            "mglt": "100",
            "cargoCapacity": "110",
            "consumables": "1 week",
            "createdAt": "2014-12-12T11:19:05.34Z",
            "updatedAt": "2014-12-20T21:23:49.886Z"
        }
    ],
    "pagination": {
        "pageNumber": 1,
        "pageSize": 25,
        "pageCount": 1,
        "totalCount": 1,
        "hasPrevious": false,
        "hasNext": false
    }
}
```

### `GET /api/episodes/{episodeId}/species`

#2 - Return the classification of all species in the 1st episode

1st Star Wars episode `episodeId` is `1`. If you go by release order a.k.a. The Good Hope.
1st Star Wars episode `episodeId` is `4`. If you go by episode order a.k.a. The Phantom Menace.

Query Parameters:

- `page` - Defaults to `1`.
- `pageSize` - Defaults to `25`.

```json
{
    "species": [
        {
            "id": "1",
            "name": "Human",
            "classification": "mammal",
            "designation": "sentient",
            "averageHeight": "180",
            "averageLifespan": "120",
            "eyeColors": [
                "brown",
                "blue",
                "green",
                "hazel",
                "grey",
                "amber"
            ],
            "hairColors": [
                "blonde",
                "brown",
                "black",
                "red"
            ],
            "skinColors": [
                "caucasian",
                "black",
                "asian",
                "hispanic"
            ],
            "language": "Galactic Basic",
            "createdAt": "2014-12-10T13:52:11.567Z",
            "updatedAt": "2014-12-20T21:36:42.136Z"
        }
    ],
    "pagination": {
        "pageNumber": 1,
        "pageSize": 25,
        "pageCount": 1,
        "totalCount": 1,
        "hasPrevious": false,
        "hasNext": false
    }
}
```

### `GET /api/population`

#3 - Return the total population of all planets in the Galaxy

```json
{
    "population": 1711401432500
}
```

### Postman Collection

There is a Postman [collection](./docs/star-wars-api.collection.json) in the `docs` directory of this repository that can be used to
interact with a running instance of the Star Wars API.

The Postman Collection is also a great way to learn about the various API endpoints that are available to use.

### Support

We use GitHub for tracking bugs and feature requests related to the Star Wars API.

Don't know how something in this project works? Curious if this project can achieve your desired functionality?
Please open an issue on GitHub with the label question.
