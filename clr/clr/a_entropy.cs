using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct a_entropy
{
    public SqlDouble weight_sum;
    public SqlDouble log_sum;
    public void Init()
    {
        // Put your code here
        weight_sum = 0;
        log_sum = 0;
    }

    public void Accumulate(SqlDouble Value)
    {
        // Put your code here
        weight_sum = weight_sum + Value;
        log_sum = log_sum + Value * Math.Log((double)Value, 2);
    }

    public void Merge (a_entropy Group)
    {
        // Put your code here
        //this.weight_sum = this.weight_sum + Group.weight_sum;
        //log_sum = log_sum + Group.weight_sum;
    }

    public SqlDouble Terminate ()
    {
        // Put your code here
        return -log_sum / weight_sum + Math.Log((double)weight_sum, 2);
    }

    // This is a place-holder member field
    public int _var1;
}
