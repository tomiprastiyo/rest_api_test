using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace rest_api_test.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly rest_api_test_db _context;

        public UserController(rest_api_test_db context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usersList = _context.user;
                return Ok(usersList);
            }
            catch (Exception ex)
            {
                string StatusFail = ex.Message;
                return BadRequest(StatusFail);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var usersList = _context.user.Where(e => e.id == id).SingleOrDefault();
                return Ok(usersList);
            }
            catch (Exception ex)
            {
                string StatusFail = ex.Message;
                return BadRequest(StatusFail);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(user data)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var cekUsername = _context.user.Where(e => e.nama == data.nama).Count();

                    if (cekUsername > 0)
                    {
                        string dataDuplikat = "Nama Sudah Digunakan.";
                        return Ok(dataDuplikat);
                    }

                    //save user
                    user userData = new user
                    {
                        nama = data.nama,
                        jenis_identitas = data.jenis_identitas,
                        no_identitas = data.no_identitas,
                        tempat = data.tempat,
                        tgl_lahir = data.tgl_lahir,
                        jenis_kelamin = data.jenis_kelamin,
                        alamat = data.alamat,
                        input_by = User.Identity.Name,
                        input_date = DateTime.Now,
                    };

                    _context.user.Add(userData); //insert user yg diconstruct

                    await _context.SaveChangesAsync(); //save changes to database
                    transaction.Commit();

                    return Ok(userData);
                }
                catch (Exception ex)
                {
                    string StatusFail = ex.Message;
                    transaction.Rollback();

                    return BadRequest(StatusFail);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, user data)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var cekUsername = _context.user.Where(e => e.nama == data.nama && e.id != id).Count();

                    if (cekUsername > 0)
                    {
                        string dataDuplikat = "Nama Sudah Digunakan.";
                        return Ok(dataDuplikat);
                    }

                    //edit data user
                    var updateUser = (
                                from a in _context.user
                                where a.id == id
                                select a).SingleOrDefault();

                    updateUser.nama = data.nama;
                    updateUser.jenis_identitas = data.jenis_identitas;
                    updateUser.no_identitas = data.no_identitas;
                    updateUser.tempat = data.tempat;
                    updateUser.tgl_lahir = data.tgl_lahir;
                    updateUser.jenis_kelamin = data.jenis_kelamin;
                    updateUser.alamat = data.alamat;
                    updateUser.input_by = User.Identity.Name;
                    updateUser.input_date = DateTime.Now;

                    _context.user.Update(updateUser);

                    await _context.SaveChangesAsync(); //save changes to database
                    transaction.Commit();

                    return Ok(updateUser);
                }
                catch (Exception ex)
                {
                    string StatusFail = ex.Message;
                    transaction.Rollback();

                    return BadRequest(StatusFail);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, user data)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var dbRow = _context.user.SingleOrDefault(e => e.id == id);
                    if (dbRow == null)
                    {
                        string statusData = "Data tidak ditemukan!";
                        return Ok(statusData);
                    }
                    else
                    {
                        _context.user.Remove(dbRow);
                    }

                    await _context.SaveChangesAsync(); //save changes to database
                    transaction.Commit();

                    return Ok("Data Berhasil Dihapus");
                }
                catch (Exception ex)
                {
                    string StatusFail = ex.Message;
                    transaction.Rollback();

                    return BadRequest(StatusFail);
                }
            }
        }
    }
}
