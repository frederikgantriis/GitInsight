using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GitInsight.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GitInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitInsightController : ControllerBase
    {

        private readonly GitInsightContext _context;

        private CommitService _commitService;

        public GitInsightController(GitInsightContext context)
        {
            _context = context;
            _commitService = new CommitService(repository: (LibGit2Sharp.IRepository)_context.Repositories);
        }

        //Create a new user
        [HttpPost("CreateUser")]
        public JsonResult CreateUser([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return new JsonResult("User created");
        }

        //Get a user by id
        [HttpGet("GetUser/{id}")]
        public JsonResult GetUser(int id)
        {
            var user = _context.Users.Find(id);

            return new JsonResult(user);
        }

        //Get a user by name
        [HttpGet("GetUserByName/{name}")]
        public JsonResult GetUserByName(string name)
        {
            var user = _context.Users.Where(u => u.Name == name).FirstOrDefault();

            if (user == null)
            {
                return new JsonResult("User not found");
            }

            return new JsonResult(user);
        }

        //Get all users
        [HttpGet("GetAllUsers")]
        public JsonResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return new JsonResult(users);
        }

        //Delete a user
        [HttpDelete("DeleteUser/{id}")]
        public JsonResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return new JsonResult("User deleted");
        }

        //Update a user
        [HttpPut("UpdateUser/{id}")]
        public JsonResult UpdateUser(int id, User user)
        {
            var userToUpdate = _context.Users.Find(id);
            if (userToUpdate == null)
            {
                return new JsonResult("User not found");
            }
            else
            {
                userToUpdate.Name = user.Name;
                _context.SaveChanges();
                return new JsonResult("User updated successfully");
            }
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        //Create a new repository
        [HttpPost("CreateRepository")]
        public JsonResult CreateRepository(Repository repository)
        {
            _context.Repositories.Add(repository);
            _context.SaveChanges();

            return new JsonResult("Repository created");
        }

        //Get a repository by id
        [HttpGet("GetRepository/{id}")]
        public JsonResult GetRepository(int id)
        {
            var repository = _context.Repositories.Find(id);

            if (repository == null)
            {
                return new JsonResult("Repository not found");
            }

            return new JsonResult(repository);
        }

        //Get all repositories
        [HttpGet("GetAllRepositories")]
        public JsonResult GetAllRepositories()
        {
            var repositories = _context.Repositories.ToList();
            return new JsonResult(repositories);
        }

        //Delete a repository
        [HttpDelete("DeleteRepository/{id}")]
        public JsonResult  DeleteRepository(int id)
        {
            var repository = _context.Repositories.Find(id);
            if (repository == null)
            {
                return new JsonResult("Repository not found");
            }

            _context.Repositories.Remove(repository);
            _context.SaveChanges();

            return new JsonResult("Repository deleted successfully");
        }

        //Update a repository
        [HttpPut("UpdateRepository/{id}")]
        public JsonResult UpdateRepository(int id, Repository repository)
        {
            if (id != repository.Id)
            {
                return new JsonResult("Bad Request");
            }

            _context.Entry(repository).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepositoryExists(id))
                {
                    return new JsonResult("Not Found");
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("No Content");
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
        public JsonResult GetCommit(int id)
        {
            var commit = _context.Commits.Find(id);

            if (commit == null)
            {
                return new JsonResult("Commit not found");
            }

            return new JsonResult(commit);
        }

        //Get all commits
        [HttpGet("GetAllCommits")]
        public JsonResult GetAllCommits()
        {
            return new JsonResult(_context.Commits.ToList());
        }

        //Delete a commit
        [HttpDelete("DeleteCommit/{id}")]
        public JsonResult DeleteCommit(int id)
        {
            var commit = _context.Commits.Find(id);
            if (commit == null)
            {
                return new JsonResult("Commit not found");
            }

            _context.Commits.Remove(commit);
            _context.SaveChanges();

            return new JsonResult("Deleted Successfully");
        }

        //Update a commit
        [HttpPut("UpdateCommit/{id}")]
        public JsonResult UpdateCommit(int id, Commit commit)
        {
            if (id != commit.Id)
            {
                return new JsonResult("Error");
            }

            _context.Entry(commit).State = EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }

        private bool CommitExists(int id)
        {
            return _context.Commits.Any(e => e.Id == id);
        }

        //Get commits per day
        [HttpGet("GetAllCommitsFromRepository/{id}")]
        public JsonResult GetAllCommitsFromRepository(CommitService data)
        {
            var result = data.GetCommitsPerDay();
            var result1 = _commitService.GetCommitsPerDay();

            return new JsonResult(result);
        }

        //Get commits by author
        [HttpGet("GetCommitsByAuthor/{author}")]
        public JsonResult GetCommitsByAuthor(CommitService data)
        {
            var result = data.GetCommitsByAuthor();
            var result1 = _commitService.GetCommitsByAuthor();

            return new JsonResult(result);
        }
    }
}
