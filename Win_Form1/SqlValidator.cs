using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace SqlVersionManager;

internal static class SqlValidator
{
    public static string? GetError(string query)
    {
        TSqlParser parser = new TSql160Parser(true);

        using StringReader reader = new StringReader(query);
        TSqlFragment fragment = parser.Parse(reader, out IList<ParseError> errors);

        if (errors.Count > 0)
            return $"Line {errors[0].Line}: {errors[0].Message}";

        // ScriptDom accepts a bare identifier as an implicit procedure call.
        // Require EXEC explicitly so accidental text is not treated as valid SQL.
        if (fragment is TSqlScript script)
        {
            foreach (TSqlStatement statement in script.Batches.SelectMany(batch => batch.Statements))
            {
                if (statement is ExecuteStatement &&
                    statement.ScriptTokenStream[statement.FirstTokenIndex].TokenType == TSqlTokenType.Identifier)
                {
                    return $"Line {statement.StartLine}: Unrecognized statement. Use EXEC to run a procedure.";
                }
            }
        }

        return null;
    }
}
