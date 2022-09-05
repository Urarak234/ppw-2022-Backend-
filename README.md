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
      
      
