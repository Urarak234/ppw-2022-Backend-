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
      title: string(required, min: 5: max: 100),
      description: string(required, min: 6: max: 200),
      publisher: string (required, min: 6: max: 50),
      score: number(optional),
      genre: string(required, min: 1: max: 50),
      tags: string(optional)
    }
    
### Game Publisher:
    {
      id: number,
      name: string(required, min: 5: max: 100),
      description: string(required, min: 6: max: 200),
      site: string(optional)
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
- Find games by part of name. Example: If user will input Ho then endpoint will return **<mark>Ho</mark>low Knight**, **</mark>Ho</mark>gwarts Legacy**, etc.
- Get games by score
- Get games by tags
- Show only specific number of games. We'll introduce how many results would be shown to us, up to ~50
- Get all tags avialable
- Show how many games are curently in the site DB

### User authentification:

Username + Email + Pass authentification system.

### Working with files:

