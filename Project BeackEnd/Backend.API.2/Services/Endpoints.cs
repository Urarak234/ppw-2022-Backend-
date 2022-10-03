using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.API._2.Data;
using Backend.API._2.Entities;

namespace Backend.API._2.Services
{
/*    [ApiController]
    [Route("[controller]")]*/
    public class Endpoints : ControllerBase
    {
        private readonly GameStoreContext _context;

        public Endpoints (GameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(Game theGame)
        {
            var game = new Game()
            {
                id = theGame.id,
                image = theGame.image,
                title = theGame.title,
                description = theGame.description,
                publisher = theGame.publisher,
                score = theGame.score,
                genre = theGame.genre,
                type = theGame.type,
                tagsText = theGame.tagsText
            };

            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();

            return Ok(game);
        }

        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Games.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Get All
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Games.ToList();

            return new JsonResult(Ok(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGame(int id, string img, string ttl, string desc, int pblsr, double scr, string gnr, int tp, string tgs)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                game.image = img;
                game.title = ttl;
                game.description = desc;
                game.publisher = pblsr;
                game.score = scr;
                game.genre = gnr;
                game.type = tp;
                game.tagsText = tgs;

                _context.Update(game);
                _context.SaveChanges();

                return Ok(game);
            }

            return NotFound();
        }

        //Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();

                return Ok(game);
            }

            return NotFound();
        }

        //ENDPOINTS
        [HttpGet]
        public JsonResult GetByTitle(string gameTitle)
        {
            var result = _context.Games.Where(x => x.title == gameTitle);
            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetGamesByType(string type)
        {
            var theType = _context.Type.Where(x => x.type == type);

            if (theType.Count() < 1)
            {
                return new JsonResult(NotFound());
            }

            var idType = theType.First().id;
            var result = _context.Games.ToList().Where(x => x.type == idType);
            return new JsonResult(Ok(result));

        }

        [HttpGet]
        public JsonResult GetByGenre(string gameGenre)
        {
            var result = _context.Games.ToList().Where(x => x.genre == gameGenre);
            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetGamesByPublisher(string publisher)
        {
            var thePublisher = _context.Publisher.Where(x => x.name == publisher);
            if (thePublisher.Count() < 1)
            {
                return new JsonResult(NotFound());
            }

            var idPublisher = thePublisher.First().id;
            var result = _context.Games.ToList().Where(x => x.publisher == idPublisher);
            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAllPublishers()
        {
            var result = _context.Publisher.ToList();
            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetGamesByScore(double minScore, double maxScore)
        {

            var result = _context.Games.ToList().Where(x => x.score >= minScore && x.score <= maxScore);
            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetGamesByTags(string tag_1 = "Insert a Tag", string tag_2 = "Insert a Tag", string tag_3 = "Insert a Tag")
        {

            var tags = _context.Games.ToList().Select(x => x.Tags());
            var dbGames = _context.Games.ToList();

            List<int> games = new List<int>();

            int counter = 1;
            string result2 = "";

            foreach (var elem in tags)
            {
                foreach (var param in elem)
                {

                    if (tag_1 == param && tag_2 != "Insert a Tag" && tag_3 != "Insert a Tag")
                    {
                        foreach (var param2 in elem)
                        {
                            if (tag_2 == param2)
                            {
                                foreach (var param3 in elem)
                                {
                                    if (tag_3 == param3)
                                    {
                                        games.Add(counter);
                                        break;
                                    }
                                }

                            }
                        }
                    }
                    else if (tag_1 == param && tag_2 != "Insert a Tag" && tag_3 == "Insert a Tag")
                    {
                        foreach (var param2 in elem)
                        {
                            if (tag_2 == param2)
                            {
                                games.Add(counter);
                                break;
                            }
                        }
                    }
                    else if ((tag_1 == param && tag_2 == "Insert a Tag" && tag_3 == "Insert a Tag")
                        || (tag_1 == "Insert a Tag" && tag_2 == param && tag_3 == "Insert a Tag")
                        || (tag_1 == "Insert a Tag" && tag_2 == "Insert a Tag" && tag_3 == param))
                    {
                        games.Add(counter);
                        break;
                    }
                }

                counter++;
            }

            if (games.Count == 0)
                return new JsonResult(NotFound());

            var result = _context.Games.Where(x => games.Contains(x.id)).ToList();

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult ShowGamesUpTo(int maxResults, int From = 0)
        {
            if ((maxResults - _context.Games.Count()) > 0 && From != 0)
            {
                maxResults = _context.Games.Count() - (From - 1);
            }
            else
            {
                maxResults = _context.Games.Count() - From;
            }

            if (From != 0 && From <= _context.Games.Count())
            {
                var result = _context.Games.ToList().GetRange(From - 1, maxResults);
                return new JsonResult(Ok(result));
            }
            else if(From == 0)
            {
                var result = _context.Games.ToList().Where(x => x.id <= maxResults);
                return new JsonResult(Ok(result));
            }
            else if (From > _context.Games.Count())
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(NotFound());
        }

        [HttpGet]
        public JsonResult ShowAllTagsAvialable()
        {
            var tags = _context.Games.ToList().Select(x => x.Tags());
            string result = "";

            foreach (var element in tags)
            {
                foreach (var tag in element)
                {
                    result += tag + ", ";
                }
            }

            if (result == "")
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult CountAllGames()
        {
            var result = _context.Games.ToList();

            if (result.Count() == 0)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result.Count()));
        }

        //PUBLISHER CRUD
        [HttpPost]
        public async Task<IActionResult> AddPUBLISHER(Publishers thePublisher)
        {
            var publisher = new Publishers()
            {
                id = thePublisher.id,
                name = thePublisher.name,
                image = thePublisher.image,
                description = thePublisher.description,
                site = thePublisher.site,
                games = thePublisher.games,
            };

            await _context.Publisher.AddAsync(publisher);
            await _context.SaveChangesAsync();

            return Ok(publisher);
        }

        [HttpGet]
        public JsonResult GetPUBLISHER(int id)
        {
            var result = _context.Publisher.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAllPUBLISHERS()
        {
            var result = _context.Publisher.ToList();

            return new JsonResult(Ok(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePUBLISHER(int id, string name, string img, string desc, string site, int games)
        {
            var publisher = await _context.Publisher.FindAsync(id);
            if (publisher != null)
            {
                publisher.id = id;
                publisher.name = name;
                publisher.image = img;
                publisher.description = desc;
                publisher.site = site;
                publisher.games = games;

                _context.Update(publisher);
                _context.SaveChanges();

                return Ok(publisher);
            }

            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePUBLISHER(int id)
        {
            var publisher = await _context.Publisher.FindAsync(id);

            if (publisher != null)
            {
                _context.Publisher.Remove(publisher);
                _context.SaveChanges();

                return Ok(publisher);
            }

            return NotFound();
        }

        //Type CRUD
        [HttpPost]
        public async Task<IActionResult> Add_Type(Types theType)
        {
            var type = new Types()
            {
                id = theType.id,
                type = theType.type
            };

            await _context.Type.AddAsync(type);
            await _context.SaveChangesAsync();

            return Ok(type);
        }

        [HttpGet]
        public JsonResult Get_Type(int id)
        {
            var result = _context.Type.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAll_Types()
        {
            var result = _context.Type.ToList();

            return new JsonResult(Ok(result));
        }

        [HttpPut]
        public async Task<IActionResult> Update_Types(int id, string type)
        {
            var theType = await _context.Type.FindAsync(id);
            if (theType != null)
            {
                theType.id = id;
                theType.type = type;

                _context.Update(theType);
                _context.SaveChanges();

                return Ok(theType);
            }

            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete_Type(int id)
        {
            var type = await _context.Type.FindAsync(id);

            if (type != null)
            {
                _context.Type.Remove(type);
                _context.SaveChanges();

                return Ok(type);
            }

            return NotFound();
        }
    }
}
