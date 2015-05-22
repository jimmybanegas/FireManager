using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireManager.Models;

namespace FireManager.Controllers
{
    class SystemTables
    {
        public static StringBuilder GetCharacterSets(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS CHARACTER_SET_CATALOG,
					null AS CHARACTER_SET_SCHEMA,
					rdb$character_set_name AS CHARACTER_SET_NAME,
					rdb$character_set_id AS CHARACTER_SET_ID,
				    rdb$default_collate_name AS DEFAULT_COLLATION,
				    rdb$bytes_per_character AS BYTES_PER_CHARACTER,
				    rdb$description AS DESCRIPTION
				 FROM rdb$character_sets");

            if (restrictions != null)
            {
                int index = 0;

                /* CHARACTER_SET_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* CHARACTER_SET_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* CHARACTER_SET_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "rdb$character_set_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$character_set_name");

            return sql;
        }

        public static StringBuilder GetCheckConstraints(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS CONSTRAINT_CATALOG,
					null AS CONSTRAINT_SCHEMA,
					chk.rdb$constraint_name AS CONSTRAINT_NAME,
					trig.rdb$trigger_source AS CHECK_CLAUSULE,
				    trig.rdb$description AS DESCRIPTION
				FROM rdb$check_constraints chk
				    INNER JOIN rdb$triggers trig ON chk.rdb$trigger_name = trig.rdb$trigger_name");

            if (restrictions != null)
            {
                /* CONSTRAINT_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* CONSTRAINT_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* CONSTRAINT_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.Append("chk.rdb$constraint_name = @p0");
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0}", where.ToString());
            }

            sql.Append(" ORDER BY chk.rdb$constraint_name");

            return sql;
        }

        public static StringBuilder GetCheckConstraintsByTable(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS CONSTRAINT_CATALOG,
					null AS CONSTRAINT_SCHEMA,
					chktb.rdb$constraint_name AS CONSTRAINT_NAME,
					chktb.rdb$relation_name AS TABLE_NAME,
					trig.rdb$trigger_source AS CHECK_CLAUSULE,
				    trig.rdb$description AS DESCRIPTION
				FROM rdb$relation_constraints chktb
				    INNER JOIN rdb$check_constraints chk ON (chktb.rdb$constraint_name = chk.rdb$constraint_name AND chktb.rdb$constraint_type = 'CHECK')
				    INNER JOIN rdb$triggers trig ON chk.rdb$trigger_name = trig.rdb$trigger_name");

            if (restrictions != null)
            {
                int index = 0;

                /* CONSTRAINT_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* CONSTRAINT_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* CONSTRAINT_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "chktb.rdb$constraint_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY chktb.rdb$relation_name, chktb.rdb$constraint_name");

            return sql;
        }

        public static StringBuilder GetCollations(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS COLLATION_CATALOG,
					null AS COLLATION_SCHEMA,
					coll.rdb$collation_name AS COLLATION_NAME,
					cs.rdb$character_set_name AS CHARACTER_SET_NAME,
					coll.rdb$description AS DESCRIPTION
				FROM rdb$collations coll
					LEFT JOIN rdb$character_sets cs ON coll.rdb$character_set_id = cs.rdb$character_set_id");

            if (restrictions != null)
            {
                int index = 0;

                /* COLLATION_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* COLLATION_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* COLLATION_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "coll.rdb$collation_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY cs.rdb$character_set_name, coll.rdb$collation_name");

            return sql;
        }

        public static StringBuilder GetColumns(string restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rfr.rdb$relation_name AS TABLE_NAME,
					rfr.rdb$field_name AS COLUMN_NAME,
				    null AS COLUMN_DATA_TYPE,
				    fld.rdb$field_sub_type AS COLUMN_SUB_TYPE,
					CAST(fld.rdb$field_length AS integer) AS COLUMN_SIZE,
					CAST(fld.rdb$field_precision AS integer) AS NUMERIC_PRECISION,
					CAST(fld.rdb$field_scale AS integer) AS NUMERIC_SCALE,
					CAST(fld.rdb$character_length AS integer) AS CHARACTER_MAX_LENGTH,
					CAST(fld.rdb$field_length AS integer) AS CHARACTER_OCTET_LENGTH,
					rfr.rdb$field_position AS ORDINAL_POSITION,
					null AS DOMAIN_CATALOG,
					null AS DOMAIN_SCHEMA,
					rfr.rdb$field_source AS DOMAIN_NAME,
					null AS SYSTEM_DATA_TYPE,
					rfr.rdb$default_source AS COLUMN_DEFAULT,
				    fld.rdb$computed_source AS COMPUTED_SOURCE,
					fld.rdb$dimensions AS COLUMN_ARRAY,
					coalesce(fld.rdb$null_flag, rfr.rdb$null_flag) AS COLUMN_NULLABLE,
				    0 AS IS_READONLY,
					fld.rdb$field_type AS FIELD_TYPE,
					null AS CHARACTER_SET_CATALOG,
					null AS CHARACTER_SET_SCHEMA,
					cs.rdb$character_set_name AS CHARACTER_SET_NAME,
					null AS COLLATION_CATALOG,
					null AS COLLATION_SCHEMA,
					coll.rdb$collation_name AS COLLATION_NAME,
					rfr.rdb$description AS DESCRIPTION
				FROM rdb$relation_fields rfr
				    LEFT JOIN rdb$fields fld ON rfr.rdb$field_source = fld.rdb$field_name
				    LEFT JOIN rdb$character_sets cs ON cs.rdb$character_set_id = fld.rdb$character_set_id
				    LEFT JOIN rdb$collations coll ON (coll.rdb$collation_id = fld.rdb$collation_id AND coll.rdb$character_set_id = fld.rdb$character_set_id)");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "rfr.rdb$relation_name = @p{0}", index++);
                }

                /* COLUMN_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentUICulture, "rfr.rdb$field_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rfr.rdb$relation_name, rfr.rdb$field_position");

            return sql;
        }

        public static StringBuilder GetColumnPrivileges(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA, 
					rdb$relation_name AS TABLE_NAME,
					rdb$field_name AS COLUMN_NAME,
					rdb$user AS GRANTEE,
					rdb$grantor AS GRANTOR,
					rdb$privilege AS PRIVILEGE, 
					rdb$grant_option AS WITH_GRANT
				FROM rdb$user_privileges");

            where.Append("rdb$object_type = 0");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$relation_name = @p{0}", index++);
                }

                /* COLUMN_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$field_name = @p{0}", index++);
                }

                /* GRANTOR */
                if (restrictions.Length >= 6 && restrictions[5] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$grantor = @p{0}", index++);
                }

                /* GRANTEE */
                if (restrictions.Length >= 5 && restrictions[4] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$user = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$relation_name");

            return sql;
        }

        public static StringBuilder GetDomains(string restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS DOMAIN_CATALOG,
					null AS DOMAIN_SCHEMA,
					fld.rdb$field_name AS DOMAIN_NAME,
					null AS DOMAIN_DATA_TYPE,
					rdb$field_sub_type AS DOMAIN_SUB_TYPE,
					CAST(fld.rdb$field_length AS integer) AS DOMAIN_SIZE,
					CAST(fld.rdb$field_precision AS integer) AS NUMERIC_PRECISION,
					CAST(fld.rdb$field_scale  AS integer) AS NUMERIC_SCALE,
					CAST(fld.rdb$character_length AS integer) AS CHARACTER_MAX_LENGTH,
					CAST(fld.rdb$field_length AS integer) AS CHARACTER_OCTET_LENGTH,
					fld.rdb$null_flag AS COLUMN_NULLABLE,
					fld.rdb$dimensions AS COLUMN_ARRAY,
					fld.rdb$description AS DESCRIPTION,
					fld.rdb$field_type AS FIELD_TYPE,
					null AS CHARACTER_SET_CATALOG,
					null AS CHARACTER_SET_SCHEMA,
					cs.rdb$character_set_name AS CHARACTER_SET_NAME,
					null AS COLLATION_CATALOG,
					null AS COLLATION_SCHEMA,
					coll.rdb$collation_name AS COLLATION_NAME
				FROM rdb$fields fld
					LEFT JOIN rdb$character_sets cs ON cs.rdb$character_set_id = fld.rdb$character_set_id
					LEFT JOIN rdb$collations coll ON (coll.rdb$collation_id = fld.rdb$collation_id AND coll.rdb$character_set_id = fld.rdb$character_set_id)");

            where.Append("rdb$field_name NOT STARTING WITH 'RDB$'");

            if (restrictions != null)
            {
                int index = 0;

                /* DOMAIN_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* DOMAIN_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* DOMAIN_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, " AND rdb$field_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$field_name");

            return sql;
        }

        public static StringBuilder GetForeignKeys(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS CONSTRAINT_CATALOG,
					null AS CONSTRAINT_SCHEMA,
					co.rdb$constraint_name AS CONSTRAINT_NAME,
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					co.rdb$relation_name AS TABLE_NAME,
					coidxseg.rdb$field_name AS COLUMN_NAME,
					null as REFERENCED_TABLE_CATALOG,
					null as REFERENCED_TABLE_SCHEMA,
					refidx.rdb$relation_name as REFERENCED_TABLE_NAME,
					refidxseg.rdb$field_name AS REFERENCED_COLUMN_NAME,
					coidxseg.rdb$field_position as ORDINAL_POSITION
				FROM rdb$relation_constraints co
					INNER JOIN rdb$ref_constraints ref ON co.rdb$constraint_name = ref.rdb$constraint_name
					INNER JOIN rdb$indices tempidx ON co.rdb$index_name = tempidx.rdb$index_name
					INNER JOIN rdb$index_segments coidxseg ON co.rdb$index_name = coidxseg.rdb$index_name
					INNER JOIN rdb$indices refidx ON refidx.rdb$index_name = tempidx.rdb$foreign_key
					INNER JOIN rdb$index_segments refidxseg ON refidxseg.rdb$index_name = refidx.rdb$index_name AND refidxseg.rdb$field_position = coidxseg.rdb$field_position");

            where.Append("co.rdb$constraint_type = 'FOREIGN KEY'");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG	*/
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, " AND co.rdb$relation_name = @p{0}", index++);
                }

                /* CONSTRAINT_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, " AND co.rdb$constraint_name = @p{0}", index++);
                }

                /* COLUMN_NAME */
                if (restrictions.Length >= 5 && restrictions[4] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, " AND coidxseg.rdb$field_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY co.rdb$constraint_name, coidxseg.rdb$field_position");

            return sql;
        }

        public static StringBuilder GetForeignKeyColumns(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS CONSTRAINT_CATALOG,
					null AS CONSTRAINT_SCHEMA,
					co.rdb$constraint_name AS CONSTRAINT_NAME,
					null AS TABLE_CATALOG,
	                null AS TABLE_SCHEMA,
					co.rdb$relation_name AS TABLE_NAME,
					null as REFERENCED_TABLE_CATALOG,
					null as REFERENCED_TABLE_SCHEMA,
					refidx.rdb$relation_name as REFERENCED_TABLE_NAME,
					co.rdb$deferrable AS IS_DEFERRABLE,
					co.rdb$initially_deferred AS INITIALLY_DEFERRED,
					ref.rdb$match_option AS MATCH_OPTION,
					ref.rdb$update_rule AS UPDATE_RULE,
					ref.rdb$delete_rule AS DELETE_RULE,
					co.rdb$index_name as INDEX_NAME
				FROM rdb$relation_constraints co
	                INNER JOIN rdb$ref_constraints ref ON co.rdb$constraint_name = ref.rdb$constraint_name
					INNER JOIN rdb$indices tempidx ON co.rdb$index_name = tempidx.rdb$index_name
					INNER JOIN rdb$indices refidx ON refidx.rdb$index_name = tempidx.rdb$foreign_key");

            where.Append("co.rdb$constraint_type = 'FOREIGN KEY'");

            if (restrictions != null)
            {
                int index = 0;

                /* CONSTRAINT_CATALOG	*/
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* CONSTRAINT_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, " AND co.rdb$relation_name = @p{0}", index++);
                }

                /* CONSTRAINT_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, " AND rel.rdb$constraint_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY co.rdb$relation_name, co.rdb$constraint_name");

            return sql;
        }

        public static StringBuilder GetFunctions(string restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS FUNCTION_CATALOG,
					null AS FUNCTION_SCHEMA,
					rdb$function_name AS FUNCTION_NAME,
					rdb$system_flag AS IS_SYSTEM_FUNCTION,
					rdb$function_type AS FUNCTION_TYPE,
					rdb$query_name AS QUERY_NAME,
					rdb$module_name AS FUNCTION_MODULE_NAME,
					rdb$entrypoint AS FUNCTION_ENTRY_POINT,
					rdb$return_argument AS RETURN_ARGUMENT,
					rdb$description AS DESCRIPTION
				FROM rdb$functions");

            if (restrictions != null)
            {
                int index = 0;

                /* FUNCTION_CATALOG	*/
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* FUNCTION_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* FUNCTION_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, "rdb$function_name = @p{0}", index++);
                }

                /* IS_SYSTEM_FUNCTION */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentCulture, "rdb$system_flag = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$function_name");

            return sql;
        }

        public static StringBuilder GetGenerators(string restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS GENERATOR_CATALOG,
					null AS GENERATOR_SCHEMA,
					rdb$generator_name AS GENERATOR_NAME,
					rdb$system_flag AS IS_SYSTEM_GENERATOR,
					rdb$generator_id AS GENERATOR_ID
				FROM rdb$generators");

            if (restrictions != null)
            {
                int index = 0;

                /* GENERATOR_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* GENERATOR_SCHEMA	*/
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* GENERATOR_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, "rdb$generator_name = @p{0}", index++);
                }

                /* IS_SYSTEM_GENERATOR	*/
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentCulture, "rdb$system_flag = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$generator_name");

            return sql;
        }

        public static StringBuilder GetIndexes(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					idx.rdb$relation_name AS TABLE_NAME,
					idx.rdb$index_name AS INDEX_NAME,
					idx.rdb$index_inactive AS IS_INACTIVE,
					idx.rdb$unique_flag AS IS_UNIQUE,
				    (SELECT COUNT(*) FROM rdb$relation_constraints rel
				    WHERE rel.rdb$constraint_type = 'PRIMARY KEY' AND rel.rdb$index_name = idx.rdb$index_name AND rel.rdb$relation_name = idx.rdb$relation_name) as PRIMARY_KEY,
					(SELECT COUNT(*) FROM rdb$relation_constraints rel
					WHERE rel.rdb$constraint_type = 'UNIQUE' AND rel.rdb$index_name = idx.rdb$index_name AND rel.rdb$relation_name = idx.rdb$relation_name) as UNIQUE_KEY,
					idx.rdb$system_flag AS IS_SYSTEM_INDEX,
					idx.rdb$index_type AS INDEX_TYPE,
					idx.rdb$description AS DESCRIPTION
				FROM rdb$indices idx");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA	*/
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, "idx.rdb$relation_name = @p{0}", index++);
                }

                /* INDEX_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentCulture, "idx.rdb$index_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY idx.rdb$relation_name, idx.rdb$index_name");

            return sql;
        }

        public static StringBuilder GetIndexColumns(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS CONSTRAINT_CATALOG,
					null AS CONSTRAINT_SCHEMA,
					idx.rdb$index_name AS CONSTRAINT_NAME,
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					idx.rdb$relation_name AS TABLE_NAME,
					seg.rdb$field_name AS COLUMN_NAME,
					seg.rdb$field_position AS ORDINAL_POSITION,
					idx.rdb$index_name AS INDEX_NAME
				FROM rdb$indices idx
					LEFT JOIN rdb$index_segments seg ON idx.rdb$index_name = seg.rdb$index_name");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA	*/
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, "idx.rdb$relation_name = @p{0}", index++);
                }

                /* INDEX_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentCulture, "idx.rdb$index_name = @p{0}", index++);
                }

                /* COLUMN_NAME */
                if (restrictions.Length >= 5 && restrictions[4] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentCulture, "seg.rdb$field_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY idx.rdb$relation_name, idx.rdb$index_name, seg.rdb$field_position");

            return sql;
        }

        public static StringBuilder GetPrimaryKeys(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rel.rdb$relation_name AS TABLE_NAME,
					seg.rdb$field_name AS COLUMN_NAME,
					seg.rdb$field_position AS ORDINAL_POSITION,
					rel.rdb$constraint_name AS PK_NAME
				FROM rdb$relation_constraints rel
					LEFT JOIN rdb$indices idx ON rel.rdb$index_name = idx.rdb$index_name
					LEFT JOIN rdb$index_segments seg ON idx.rdb$index_name = seg.rdb$index_name");

            where.Append("rel.rdb$constraint_type = 'PRIMARY KEY'");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA	*/
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentCulture, " AND rel.rdb$relation_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentCulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rel.rdb$relation_name, rel.rdb$constraint_name, seg.rdb$field_position");

            return sql;
        }

        public static StringBuilder GetProcedureParameters(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS PROCEDURE_CATALOG,
					null AS PROCEDURE_SCHEMA,
					rdb$procedure_name AS PROCEDURE_NAME,
					rdb$procedure_inputs AS INPUTS,
					rdb$procedure_outputs AS OUTPUTS,
					rdb$system_flag AS IS_SYSTEM_PROCEDURE,
					rdb$procedure_source AS SOURCE,
					rdb$description AS DESCRIPTION
				FROM rdb$procedures");

            if (restrictions != null)
            {
                int index = 0;

                /* PROCEDURE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* PROCEDURE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* PROCEDURE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "rdb$procedure_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$procedure_name");

            return sql;
        }

        public static StringBuilder GetProcedurePrivileges(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS PROCEDURE_CATALOG,
					null AS PROCEDURE_SCHEMA,
					rdb$relation_name AS PROCEDURE_NAME,
					rdb$user AS GRANTEE,
					rdb$grantor AS GRANTOR,
					rdb$privilege AS PRIVILEGE,
					rdb$grant_option AS WITH_GRANT
				FROM rdb$user_privileges");

            where.Append("rdb$object_type = 5");

            if (restrictions != null)
            {
                int index = 0;

                /* PROCEDURE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* PROCEDURE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* PROCEDURE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$relation_name = @p{0}", index++);
                }

                /* GRANTOR */
                if (restrictions.Length >= 5 && restrictions[4] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$grantor = @p{0}", index++);
                }

                /* GRANTEE */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$user = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$relation_name");

            return sql;
        }

        public static StringBuilder GetProcedures(string restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS PROCEDURE_CATALOG,
					null AS PROCEDURE_SCHEMA,
					rdb$procedure_name AS PROCEDURE_NAME,
					rdb$procedure_inputs AS INPUTS,
					rdb$procedure_outputs AS OUTPUTS,
					rdb$system_flag AS IS_SYSTEM_PROCEDURE,
					rdb$procedure_source AS SOURCE,
					rdb$description AS DESCRIPTION
				FROM rdb$procedures");

            if (restrictions != null)
            {
                int index = 0;

                /* PROCEDURE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* PROCEDURE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* PROCEDURE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "rdb$procedure_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$procedure_name");

            return sql;
        }

        public static StringBuilder GetDataTypes(string[] restrictions)
        {
            return null;
        }

        public static StringBuilder GetRoles(string[] restrictions)
        {
            return null;
        }

        public static StringBuilder GetTables(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rdb$relation_name AS TABLE_NAME,
					null AS TABLE_TYPE,
					rdb$system_flag AS IS_SYSTEM_TABLE,
					rdb$owner_name AS OWNER_NAME,
					rdb$description AS DESCRIPTION,
					rdb$view_source AS VIEW_SOURCE
				FROM rdb$relations");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "rdb$relation_name = @p{0}", index++);
                }

                /* TABLE_TYPE */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    switch (restrictions[3].ToString())
                    {
                        case "VIEW":
                            where.Append("rdb$view_source IS NOT NULL");
                            break;

                        case "SYSTEM TABLE":
                            where.Append("rdb$view_source IS NULL and rdb$system_flag = 1");
                            break;

                        case "TABLE":
                        default:
                            where.Append("rdb$view_source IS NULL and rdb$system_flag = 0");
                            break;
                    }
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$system_flag, rdb$owner_name, rdb$relation_name");

            return sql;
        }

        public static StringBuilder GetTableConstraints(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS CONSTRAINT_CATALOG,
					null AS CONSTRAINT_SCHEMA,
					rc.rdb$constraint_name AS CONSTRAINT_NAME,
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rc.rdb$relation_name AS TABLE_NAME,
					rc.rdb$constraint_type AS CONSTRAINT_TYPE,
				    rc.rdb$deferrable AS IS_DEFERRABLE,
				    rc.rdb$initially_deferred AS INITIALLY_DEFERRED
				FROM rdb$relation_constraints rc");

            if (restrictions != null)
            {
                int index = 0;

                /* CONSTRAINT_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* CONSTRAINT_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* CONSTRAINT_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentUICulture, "rc.rdb$constraint_name = @p{0}", index++);
                }

                /* TABLE_CATALOG */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 5 && restrictions[4] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 6 && restrictions[5] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentUICulture, "rc.rdb$relation_name = @p{0}", index++);
                }

                /* CONSTRAINT_TYPE */
                if (restrictions.Length >= 7 && restrictions[6] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentUICulture, "rc.rdb$constraint_type = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rc.rdb$relation_name, rc.rdb$constraint_name");

            return sql;
        }

        public static StringBuilder GetTablePrivileges(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rdb$relation_name AS TABLE_NAME,
					rdb$user AS GRANTEE,
					rdb$grantor AS GRANTOR,
					rdb$privilege AS PRIVILEGE,
					rdb$grant_option AS WITH_GRANT
				FROM rdb$user_privileges");

            where.Append("rdb$object_type = 0");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$relation_name = @p{0}", index++);
                }

                /* GRANTOR */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$grantor = @p{0}", index++);
                }

                /* GRANTEE */
                if (restrictions.Length >= 5 && restrictions[4] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rdb$user = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$relation_name");

            return sql;
        }

        public static StringBuilder GetTriggers(string restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rdb$relation_name AS TABLE_NAME,
					rdb$trigger_name AS TRIGGER_NAME, 
					rdb$system_flag AS IS_SYSTEM_TRIGGER,
					rdb$trigger_type AS TRIGGER_TYPE,
					rdb$trigger_inactive AS IS_INACTIVE,
					rdb$trigger_sequence AS SEQUENCE,
					rdb$trigger_source AS SOURCE,
					rdb$description AS DESCRIPTION
				FROM rdb$triggers");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, "rdb$relation_name = @p{0}", index++);
                }

                /* TRIGGER_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    if (where.Length > 0)
                    {
                        where.Append(" AND ");
                    }

                    where.AppendFormat(CultureInfo.CurrentUICulture, "rdb$trigger_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rdb$relation_name, rdb$trigger_name");

            return sql;
        }

        public static StringBuilder GetUniqueKeys(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS TABLE_CATALOG,
					null AS TABLE_SCHEMA,
					rel.rdb$relation_name AS TABLE_NAME,
					seg.rdb$field_name AS COLUMN_NAME,
					seg.rdb$field_position AS ORDINAL_POSITION,
					rel.rdb$constraint_name AS UK_NAME
				FROM rdb$relation_constraints rel
					LEFT JOIN rdb$indices idx ON rel.rdb$index_name = idx.rdb$index_name
					LEFT JOIN rdb$index_segments seg ON idx.rdb$index_name = seg.rdb$index_name");

            where.Append("rel.rdb$constraint_type = 'UNIQUE'");

            if (restrictions != null)
            {
                int index = 0;

                /* TABLE_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* TABLE_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* TABLE_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rel.rdb$relation_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rel.rdb$relation_name, rel.rdb$constraint_name, seg.rdb$field_position");

            return sql;
        }

        public static StringBuilder GetViewColumns(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS VIEW_CATALOG,
					null AS VIEW_SCHEMA,
					rel.rdb$relation_name AS VIEW_NAME,
					rfr.rdb$field_name AS COLUMN_NAME,
					null AS COLUMN_DATA_TYPE,
					fld.rdb$field_sub_type AS COLUMN_SUB_TYPE,
					CAST(fld.rdb$field_length AS integer) AS COLUMN_SIZE,
					CAST(fld.rdb$field_precision AS integer) AS NUMERIC_PRECISION,
					CAST(fld.rdb$field_scale AS integer) AS NUMERIC_SCALE,
					CAST(fld.rdb$character_length AS integer) AS CHARACTER_MAX_LENGTH,
					CAST(fld.rdb$field_length AS integer) AS CHARACTER_OCTET_LENGTH,
					rfr.rdb$field_position AS ORDINAL_POSITION,
					fld.rdb$default_source AS COLUMN_DEFAULT,
					fld.rdb$null_flag AS COLUMN_NULLABLE,
					fld.rdb$dimensions AS COLUMN_ARRAY,
					0 AS IS_READONLY,
					fld.rdb$field_type AS FIELD_TYPE,
					null AS CHARACTER_SET_CATALOG,
					null AS CHARACTER_SET_SCHEMA,
					cs.rdb$character_set_name AS CHARACTER_SET_NAME,
					null AS COLLATION_CATALOG,
					null AS COLLATION_SCHEMA,
					coll.rdb$collation_name AS COLLATION_NAME,
					rfr.rdb$description AS DESCRIPTION
				FROM rdb$relations rel
					LEFT JOIN rdb$relation_fields rfr ON rel.rdb$relation_name = rfr.rdb$relation_name
					LEFT JOIN rdb$fields fld ON rfr.rdb$field_source = fld.rdb$field_name
					LEFT JOIN rdb$character_sets cs ON cs.rdb$character_set_id = fld.rdb$character_set_id
				    LEFT JOIN rdb$collations coll ON (coll.rdb$collation_id = fld.rdb$collation_id AND coll.rdb$character_set_id = fld.rdb$character_set_id)");

            where.Append("rel.rdb$view_source IS NOT NULL");

            if (restrictions != null)
            {
                int index = 0;

                /* VIEW_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* VIEW_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* VIEW_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rel.rdb$relation_name = @p{0}", index++);
                }

                /* COLUMN_NAME */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rfr.rdb$field_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rel.rdb$relation_name, rfr.rdb$field_position");

            return sql;
        }

        public static StringBuilder GetViews(string restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS VIEW_CATALOG,
					null AS VIEW_SCHEMA,
					rel.rdb$relation_name AS VIEW_NAME,
					rel.rdb$system_flag AS IS_SYSTEM_VIEW,
					rel.rdb$view_source AS DEFINITION,
					rel.rdb$description AS DESCRIPTION
				FROM rdb$relations rel");

            where.Append("rel.rdb$view_source IS NOT NULL");

            if (restrictions != null)
            {
                int index = 0;

                /* VIEW_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* VIEW_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* VIEW_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND rel.rdb$relation_name = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY rel.rdb$relation_name");

            return sql;
        }

        public static StringBuilder GetViewPrivileges(string[] restrictions)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder where = new StringBuilder();

            sql.Append(
                @"SELECT
					null AS VIEW_CATALOG,
					null AS VIEW_SCHEMA,
					priv.rdb$relation_name AS VIEW_NAME,
					priv.rdb$user AS GRANTEE,
					priv.rdb$grantor AS GRANTOR,
					priv.rdb$privilege AS PRIVILEGE,
					priv.rdb$grant_option AS WITH_GRANT
				FROM rdb$user_privileges priv
					LEFT JOIN rdb$relations rel ON priv.rdb$relation_name = rel.rdb$relation_name");

            where.Append("priv.rdb$object_type = 0");
            where.Append(" AND rel.rdb$view_source IS NOT NULL");

            if (restrictions != null)
            {
                int index = 0;

                /* VIEW_CATALOG */
                if (restrictions.Length >= 1 && restrictions[0] != null)
                {
                }

                /* VIEW_SCHEMA */
                if (restrictions.Length >= 2 && restrictions[1] != null)
                {
                }

                /* VIEW_NAME */
                if (restrictions.Length >= 3 && restrictions[2] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND priv.rdb$relation_name = @p{0}", index++);
                }

                /* GRANTOR */
                if (restrictions.Length >= 4 && restrictions[3] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND priv.rdb$grantor = @p{0}", index++);
                }

                /* GRANTEE */
                if (restrictions.Length >= 5 && restrictions[4] != null)
                {
                    where.AppendFormat(CultureInfo.CurrentUICulture, " AND priv.rdb$user = @p{0}", index++);
                }
            }

            if (where.Length > 0)
            {
                sql.AppendFormat(CultureInfo.CurrentUICulture, " WHERE {0} ", where.ToString());
            }

            sql.Append(" ORDER BY priv.rdb$relation_name, priv.rdb$user");

            return sql;
        }

    }
}
