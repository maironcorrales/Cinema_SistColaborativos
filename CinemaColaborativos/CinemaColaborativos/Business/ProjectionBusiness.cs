using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CinemaColaborativos.Business
{
    public class ProjectionBusiness
    {
        DB_A14118_colaborativosEntities dbContex = new DB_A14118_colaborativosEntities();

        public List<proyeccion> GetProjectionsWithMovieIDAsociated(int movieID)
        {
            List<proyeccion> projectionList = new List<proyeccion>();
            projectionList = dbContex.proyeccion.Where(b => b.pelicula_id_pelicula == movieID).ToList();
            return projectionList;
        }

        public proyeccion GetProjectionByID(int id)
        {
            return dbContex.proyeccion.Where(p => p.id_proyeccion == id).FirstOrDefault();
        }

        public bool CreateProjection(proyeccion projection)
        {
            dbContex.proyeccion.Add(projection);
            if (dbContex.SaveChanges()==1)
                return true;
            else
                return false;
        }

        public bool ChangeStatus(int id)
        {
            proyeccion pro = new proyeccion();
            pro = dbContex.proyeccion.Where(p => p.id_proyeccion == id).FirstOrDefault();
            if (pro.estado_proyeccion == true)
                pro.estado_proyeccion = false;
            else
                pro.estado_proyeccion = true;
            if (dbContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool DeleteProjection(int id)
        {
            proyeccion pro = new proyeccion();
            pro = dbContex.proyeccion.Where(p => p.id_proyeccion == id).FirstOrDefault();
            dbContex.proyeccion.Remove(pro);
            if (dbContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool UpdateProjection(proyeccion projection)
        {
            proyeccion pro = dbContex.proyeccion.Where(p => p.id_proyeccion == projection.id_proyeccion).FirstOrDefault();
            pro.fecha = projection.fecha;
            pro.hora = projection.hora;
            pro.sala_id_sala = projection.sala_id_sala;
            if (dbContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        //Método que me devuelve el detalle de una factura
        public DataTable consultaFactura(int idFactura, string correo, string pelicula)
        {
            DataTable dt;
            if (idFactura > 0 && correo == "" && pelicula == "")
            {
                var resultado = (from pr in dbContex.proyeccion
                                 join
      p in dbContex.pelicula on pr.pelicula_id_pelicula equals p.id_pelicula
                                 join
r in dbContex.reservacion on pr.id_proyeccion equals r.proyeccion_id_proyeccion
                                 join
fa in dbContex.factura on r.id_reservacion equals fa.reservacion_id_reservacion
                                 join
rs in dbContex.reservacion_has_silla on r.id_reservacion equals rs.reservacion_id_reservacion
                                 join
s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                 join
si in dbContex.silla on rs.silla_id_silla equals si.id_silla
                                 join
u in dbContex.usuario on r.usuario_id_usuario equals u.id_usuario
                                 where p.id_pelicula == r.proyeccion_pelicula_id_pelicula && s.id_sala == si.sala_id_sala && fa.reservacion_usuario_id_usuario == u.id_usuario && fa.id_factura == idFactura
                                 select new { p.genero, p.nombre, r.id_reservacion, r.estado_reservacion, fa.id_factura, fa.fecha, fa.monto, fa.descripcion, s.tipo_sala, s.id_sala, u.correo, p.foto }
                                ).ToList();
                dt = LINQToDataTable(resultado);
                return dt;
            }
            else
            {
                if (idFactura == 0 && correo == "" && pelicula == "")
                {
                    var resultado = (from pr in dbContex.proyeccion
                                     join
          p in dbContex.pelicula on pr.pelicula_id_pelicula equals p.id_pelicula
                                     join
    r in dbContex.reservacion on pr.id_proyeccion equals r.proyeccion_id_proyeccion
                                     join
    fa in dbContex.factura on r.id_reservacion equals fa.reservacion_id_reservacion
                                     join
    rs in dbContex.reservacion_has_silla on r.id_reservacion equals rs.reservacion_id_reservacion
                                     join
    s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                     join
    si in dbContex.silla on rs.silla_id_silla equals si.id_silla
                                     join
    u in dbContex.usuario on r.usuario_id_usuario equals u.id_usuario
                                     where p.id_pelicula == r.proyeccion_pelicula_id_pelicula && s.id_sala == si.sala_id_sala && fa.reservacion_usuario_id_usuario == u.id_usuario
                                     select new { p.genero, p.nombre, r.id_reservacion, r.estado_reservacion, fa.id_factura, fa.fecha, fa.monto, fa.descripcion, s.tipo_sala, s.id_sala, u.correo, p.foto }
                                ).ToList();
                    dt = LINQToDataTable(resultado);
                    return dt;

                }else
                {
                    if (idFactura > 0 && correo != "" && pelicula == "")
                    {
                        var resultado = (from pr in dbContex.proyeccion
                                         join
              p in dbContex.pelicula on pr.pelicula_id_pelicula equals p.id_pelicula
                                         join
        r in dbContex.reservacion on pr.id_proyeccion equals r.proyeccion_id_proyeccion
                                         join
        fa in dbContex.factura on r.id_reservacion equals fa.reservacion_id_reservacion
                                         join
        rs in dbContex.reservacion_has_silla on r.id_reservacion equals rs.reservacion_id_reservacion
                                         join
        s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                         join
        si in dbContex.silla on rs.silla_id_silla equals si.id_silla
                                         join
        u in dbContex.usuario on r.usuario_id_usuario equals u.id_usuario
                                         where p.id_pelicula == r.proyeccion_pelicula_id_pelicula && s.id_sala == si.sala_id_sala && fa.reservacion_usuario_id_usuario == u.id_usuario && u.correo==correo && fa.id_factura ==idFactura
                                         select new { p.genero, p.nombre, r.id_reservacion, r.estado_reservacion, fa.id_factura, fa.fecha, fa.monto, fa.descripcion, s.tipo_sala, s.id_sala, u.correo, p.foto }
                                    ).ToList();
                        dt = LINQToDataTable(resultado);
                        return dt;

                    }
                    else
                    {
                        if (idFactura > 0 && correo != "" && pelicula != "")
                        {
                            var resultado = (from pr in dbContex.proyeccion
                                             join
                  p in dbContex.pelicula on pr.pelicula_id_pelicula equals p.id_pelicula
                                             join
            r in dbContex.reservacion on pr.id_proyeccion equals r.proyeccion_id_proyeccion
                                             join
            fa in dbContex.factura on r.id_reservacion equals fa.reservacion_id_reservacion
                                             join
            rs in dbContex.reservacion_has_silla on r.id_reservacion equals rs.reservacion_id_reservacion
                                             join
            s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                             join
            si in dbContex.silla on rs.silla_id_silla equals si.id_silla
                                             join
            u in dbContex.usuario on r.usuario_id_usuario equals u.id_usuario
                                             where p.id_pelicula == r.proyeccion_pelicula_id_pelicula && s.id_sala == si.sala_id_sala && fa.reservacion_usuario_id_usuario == u.id_usuario && p.nombre == pelicula && fa.id_factura == idFactura && u.correo == correo
                                             select new { p.genero, p.nombre, r.id_reservacion, r.estado_reservacion, fa.id_factura, fa.fecha, fa.monto, fa.descripcion, s.tipo_sala, s.id_sala, u.correo, p.foto }
                                        ).ToList();
                            dt = LINQToDataTable(resultado);
                            return dt;

                        }
                        else
                        {
                            if (idFactura > 0 && correo == "" && pelicula != "")
                            {
                                var resultado = (from pr in dbContex.proyeccion
                                                 join
                      p in dbContex.pelicula on pr.pelicula_id_pelicula equals p.id_pelicula
                                                 join
                r in dbContex.reservacion on pr.id_proyeccion equals r.proyeccion_id_proyeccion
                                                 join
                fa in dbContex.factura on r.id_reservacion equals fa.reservacion_id_reservacion
                                                 join
                rs in dbContex.reservacion_has_silla on r.id_reservacion equals rs.reservacion_id_reservacion
                                                 join
                s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                                 join
                si in dbContex.silla on rs.silla_id_silla equals si.id_silla
                                                 join
                u in dbContex.usuario on r.usuario_id_usuario equals u.id_usuario
                                                 where p.id_pelicula == r.proyeccion_pelicula_id_pelicula && s.id_sala == si.sala_id_sala && fa.reservacion_usuario_id_usuario == u.id_usuario && p.nombre == pelicula && fa.id_factura == idFactura
                                                 select new { p.genero, p.nombre, r.id_reservacion, r.estado_reservacion, fa.id_factura, fa.fecha, fa.monto, fa.descripcion, s.tipo_sala, s.id_sala, u.correo, p.foto }
                                            ).ToList();
                                dt = LINQToDataTable(resultado);
                                return dt;

                            }
                            else
                            {
                                if (idFactura == 0 && correo != "" && pelicula != "")
                                {
                                    var resultado = (from pr in dbContex.proyeccion
                                                     join
                          p in dbContex.pelicula on pr.pelicula_id_pelicula equals p.id_pelicula
                                                     join
                    r in dbContex.reservacion on pr.id_proyeccion equals r.proyeccion_id_proyeccion
                                                     join
                    fa in dbContex.factura on r.id_reservacion equals fa.reservacion_id_reservacion
                                                     join
                    rs in dbContex.reservacion_has_silla on r.id_reservacion equals rs.reservacion_id_reservacion
                                                     join
                    s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                                     join
                    si in dbContex.silla on rs.silla_id_silla equals si.id_silla
                                                     join
                    u in dbContex.usuario on r.usuario_id_usuario equals u.id_usuario
                                                     where p.id_pelicula == r.proyeccion_pelicula_id_pelicula && s.id_sala == si.sala_id_sala && fa.reservacion_usuario_id_usuario == u.id_usuario && p.nombre == pelicula
                                                     select new { p.genero, p.nombre, r.id_reservacion, r.estado_reservacion, fa.id_factura, fa.fecha, fa.monto, fa.descripcion, s.tipo_sala, s.id_sala, u.correo, p.foto }
                                                ).ToList();
                                    dt = LINQToDataTable(resultado);
                                    return dt;

                                }
                                else
                                {
                                    var resultado = (from pr in dbContex.proyeccion
                                                     join
                          p in dbContex.pelicula on pr.pelicula_id_pelicula equals p.id_pelicula
                                                     join
                    r in dbContex.reservacion on pr.id_proyeccion equals r.proyeccion_id_proyeccion
                                                     join
                    fa in dbContex.factura on r.id_reservacion equals fa.reservacion_id_reservacion
                                                     join
                    rs in dbContex.reservacion_has_silla on r.id_reservacion equals rs.reservacion_id_reservacion
                                                     join
                    s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                                     join
                    si in dbContex.silla on rs.silla_id_silla equals si.id_silla
                                                     join
                    u in dbContex.usuario on r.usuario_id_usuario equals u.id_usuario
                                                     where p.id_pelicula == r.proyeccion_pelicula_id_pelicula && s.id_sala == si.sala_id_sala && fa.reservacion_usuario_id_usuario == u.id_usuario 
                                                     select new { p.genero, p.nombre, r.id_reservacion, r.estado_reservacion, fa.id_factura, fa.fecha, fa.monto, fa.descripcion, s.tipo_sala, s.id_sala, u.correo, p.foto }
                                             ).ToList();
                                    dt = LINQToDataTable(resultado);
                                    return dt;
                                }
                            }
                        }
                    }
                }

            }

        }

        public DataTable consultaProyeccion(string nombrePelicula, DateTime fechaDesde, DateTime fechaHasta )
        {
            DataTable dt;
            //Consulta que devuelve solo la proyección de una película
            if (nombrePelicula != "Seleccione una película")
            {
                var resultado = (
                                from p in dbContex.pelicula
                                join pr in dbContex.proyeccion on p.id_pelicula equals pr.pelicula_id_pelicula join
                                s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                where p.nombre == nombrePelicula && pr.fechaInicio >= fechaDesde && pr.fechaInicio <= fechaHasta
                                select new { p.genero, p.nombre, p.foto, p.resumen, pr.fecha, pr.hora, pr.estado_proyeccion,s.id_sala,s.tipo_sala, p.duracion, p.id_pelicula,pr.fechaInicio }
                                 ).ToList();
                dt = LINQToDataTable(resultado);
                return dt;

            }
            else
            {
                //Consulta que devuelve todas las proyecciones

                    var resultado = (
                                    from p in dbContex.pelicula join
                                    pr in dbContex.proyeccion on p.id_pelicula equals pr.pelicula_id_pelicula join
                                    s in dbContex.sala on pr.sala_id_sala equals s.id_sala
                                    select new { p.genero, p.nombre, p.foto, p.resumen, pr.fecha, pr.hora, pr.estado_proyeccion, s.id_sala, s.tipo_sala,p.duracion,p.id_pelicula,pr.fechaInicio }
                                    ).ToList();
                    dt = LINQToDataTable(resultado);
                    return dt;
            }
        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();


            // column names
            PropertyInfo[] oProps = null;


            if (varlist == null) return dtReturn;


            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;


                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }


                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }


                DataRow dr = dtReturn.NewRow();


                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }


                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }
}