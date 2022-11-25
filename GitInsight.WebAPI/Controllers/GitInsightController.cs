using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GitInsight.Infrastructure;
using NuGet.Protocol.Core.Types;

namespace GitInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitInsightController : ControllerBase
    {

        private readonly GitInsightContext _context;

        public GitInsightController(GitInsightContext context)
        {
            _context = context;
        }

        // GET: api/GitInsight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GitInsight>>> GetGitInsights()
        {
            return await _context.GitInsights.ToListAsync();
        }

        // GET: api/GitInsight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GitInsight>> GetGitInsight(int id)
        {
            var gitInsight = await _context.GitInsights.FindAsync(id);

            if (gitInsight == null)
            {
                return NotFound();
            }

            return gitInsight;
        }

        // PUT: api/GitInsight/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGitInsight(int id, GitInsight gitInsight)
        {
            if (id != gitInsight.Id)
            {
                return BadRequest();
            }

            _context.Entry(gitInsight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GitInsightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GitInsight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GitInsight>> PostGitInsight(GitInsight gitInsight)
        {
            _context.GitInsights.Add(gitInsight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGitInsight", new { id = gitInsight.Id }, gitInsight);
        }

        // DELETE: api/GitInsight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGitInsight(int id)
        {
            var gitInsight = await _context.GitInsights.FindAsync(id);
            if (gitInsight == null)
            {
                return NotFound();
            }

            _context.GitInsights.Remove(gitInsight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GitInsightExists(int id)
        {
            return _context.GitInsights.Any(e => e.Id == id);
        }

        //Create a new user
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        //Get a user by id
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //Get a user by name
        [HttpGet("GetUserByName/{name}")]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            var user = await _context.Users.FindAsync(name);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //Get all users
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //Delete a user
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Update a user
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        //Create a new repository
        [HttpPost("CreateRepository")]
        public async Task<ActionResult<Repository>> CreateRepository(Repository repository)
        {
            _context.Repositories.Add(repository);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepository", new { id = repository.Id }, repository);
        }

        //Get a repository by id
        [HttpGet("GetRepository/{id}")]
        public async Task<ActionResult<Repository>> GetRepository(int id)
        {
            var repository = await _context.Repositories.FindAsync(id);

            if (repository == null)
            {
                return NotFound();
            }

            return repository;
        }

        //Get a repository by name
        [HttpGet("GetRepositoryByName/{name}")]
        public async Task<ActionResult<Repository>> GetRepositoryByName(string name)
        {
            var repository = await _context.Repositories.FindAsync(name);

            if (repository == null)
            {
                return NotFound();
            }

            return repository;
        }

        //Get all repositories
        [HttpGet("GetAllRepositories")]
        public async Task<ActionResult<IEnumerable<Repository>>> GetAllRepositories()
        {
            return await _context.Repositories.ToListAsync();
        }

        //Delete a repository
        [HttpDelete("DeleteRepository/{id}")]
        public async Task<IActionResult> DeleteRepository(int id)
        {
            var repository = await _context.Repositories.FindAsync(id);
            if (repository == null)
            {
                return NotFound();
            }

            _context.Repositories.Remove(repository);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Update a repository
        [HttpPut("UpdateRepository/{id}")]
        public async Task<IActionResult> UpdateRepository(int id, Repository repository)
        {
            if (id != repository.Id)
            {
                return BadRequest();
            }

            _context.Entry(repository).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepositoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool RepositoryExists(int id)
        {
            return _context.Repositories.Any(e => e.Id == id);
        }

        //Create a new commit
        [HttpPost("CreateCommit")]
        public JsonResult CreateCommit(Commit commit)
        {
            _context.Commits.Add(commit);
            _context.SaveChanges();

            return new JsonResult("Added Successfully");
        }

        //Get a commit by id
        [HttpGet("GetCommit/{id}")]
        public async Task<ActionResult<Commit>> GetCommit(int id)
        {
            var commit = await _context.Commits.FindAsync(id);

            if (commit == null)
            {
                return NotFound();
            }

            return commit;
        }

        //Get all commits
        [HttpGet("GetAllCommits")]
        public async Task<ActionResult<IEnumerable<Commit>>> GetAllCommits()
        {
            return await _context.Commits.ToListAsync();
        }

        //Delete a commit
        [HttpDelete("DeleteCommit/{id}")]
        public async Task<IActionResult> DeleteCommit(int id)
        {
            var commit = await _context.Commits.FindAsync(id);
            if (commit == null)
            {
                return NotFound();
            }

            _context.Commits.Remove(commit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Update a commit
        [HttpPut("UpdateCommit/{id}")]
        public async Task<IActionResult> UpdateCommit(int id, Commit commit)
        {
            if (id != commit.Id)
            {
                return BadRequest();
            }

            _context.Entry(commit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CommitExists(int id)
        {
            return _context.Commits.Any(e => e.Id == id);
        }
    }
}
