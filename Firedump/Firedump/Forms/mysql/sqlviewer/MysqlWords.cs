using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.Forms.mysql.sqlviewer
{
    class MysqlWords
    {
        public static readonly List<string> words = new List<string>()
        {
            "ACCOUNT",
            "ACTION",
            "ADD",
            "AFTER",
            "AGAINST",
            "ALL",
            "ALTER",
            "ALWAYS",
            "AND",
            "ANY",
            "AS",
            "ASC",
            "AT",
            "AUTO_INCREMENT",
            "BEFORE",
            "BEGIN",
            "BETWEEN",
            "BIGINT",
            "BINARY",
            "BLOB",
            "BOOL",
            "BOOLEAN",
            "BOTH",
            "INSERT",
            "INTO",
            "CASCADE",
            "CASE",
            "CHANGE",
            "CHAR",
            "COALESCE",
            "COLLATE",
            "COLUMN",
            "COLUMNS",
            "COUNT",
            "COUNT(*)",
            "COMMIT",
            "CONTAINS",
            "CREATE",
            "DATE",
            "DELETE",
            "DESC",
            "DISTINCT",
            "DROP",
            "END",
            "ENUM",
            "EXISTS",
            "SELECT",
            "UPDATE",
            "WHERE",
            "FROM",
            "LIKE",
            "INNER",
            "JOIN",
            "LEFT",
            "LIMIT",
            "OR"
        };

        public static List<string> operators = new List<string>()
        {
            "+",
            "-",
            "*",
            "/",
            "(",
            ")",
            "'",
            "\"",
            ".",
            ",",
            ";",
            "=",
            ">",
            "<",
            ">=",
            "<="
        };


        public static List<string> tables = new List<string>();

    }
}
