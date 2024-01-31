using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nightclub.Dtos;
using nightclub.Entities;
using nightclub.Models;

namespace nightclub.Controllers
{

   
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        #region Fields
        private readonly DbNightClubContext _context;
        private readonly MemberModel _memberModel;
        #endregion

        public MembersController(DbNightClubContext context, MemberModel memberModel)
        {
            _context = context;
            _memberModel = memberModel;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var res = await _memberModel.getAllMembers();
            return Ok(res);
        }

        // GET: api/Members/blacklist/id
        [HttpGet("blackList/{id}")]
        public async Task<ActionResult<IEnumerable<Member>>> BlackListMember(int id)
        {
            var res = await _memberModel.blackListMember(id);
            return Ok(res);
        }

        // put: api/Members/id
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Member>>> UpdateMember(int id, MemberDto memberdto)
        {
            try 
            {
                var res = await _memberModel.updateMember(id, memberdto);
                return Ok(res);
            } catch(Exception e)
            {
                return BadRequest(e.Message);

            }

        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(MemberDto memberdto)
        {
            
            try
            {
                var result = await _memberModel.createMember(memberdto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

     
        private bool MemberExists(int id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
