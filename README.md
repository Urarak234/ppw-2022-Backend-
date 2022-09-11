# Term of Reference

## Project Name: Game collection.

## Entities

### Game Type:
    {
      id: number,
      type: string,
    }

### Game:
    {
      id: number,
      image: string (optional, path to file),
      title: string(required, min: 5: max: 50),
      description: string(required, min: 6: max: 200),
      publisher: string (required, min: 6: max: 50),
      score: number(optional),
      genre: string(required, min: 1: max: 100),
      type: string (optional),
      tags: string(optional)
    }
    
### Game Publisher:
    {
      id: number,
      image: string (optional, path to file),
      name: string(required, min: 5: max: 100),
      description: string(required, min: 6: max: 200),
      site: string(optional),
      games: string (optional)
    }
    
### Crud Methods:

- Create 
- Read all entities
- Read one entity by id
- Update entity
- Delete entity
      
### Custom endpoints:

- Get all games
- Get all games by type
- Get game by title
- Get games by publisher
- Find games by part of name. Example: If user will input Ho then endpoint will return **`Ho`low Knight**, **`Ho`gwarts Legacy**, etc.
- Get games by score
- Get games by tags
- Show only specific number of games. We'll introduce how many results would be shown to us, up to ~50
- Get all tags avialable
- Show how many games are curently in the site DB

### User authentification:

Username + Email + Pass authentification system.

### Working with files:

At least one of entities will contain 1 or more files associated to. Example: Game entity will contain game-logo, screenshots, etc.

Will be implemented the following functionalities

- Upload file
- Delete file
- Show file

### Docker:

The application must be encapsulated in the Docker container in order to be run on any computer or smthg close

### Endpoints documentation:

Postman/Swagger - will use for docs. create.

### Endpoints testing coverage:

All enpoints must be tested.

- Create test cases
- Testing
- Create report about testing
