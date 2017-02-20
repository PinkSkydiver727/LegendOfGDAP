using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Logic {

	public List<Condition> cond;
	public List<Response> resp;

	// evaluates the condition, and if it is true, executes the response
	public bool Evaluate()
	{
		bool rval = false;

		if (cond != null)
		{
            foreach (Condition c in cond)
            {
                if (c != null)
                {
                    bool eval = c.Eval();
                    if(c.not)
                    {
                        eval = !eval;
                    }
                    if (eval == false)
                    {                        
                        return false;
                    }
                }
            }
            foreach (Response r in resp)
			{
				if (r != null)
				{
					r.Execute ();
					rval = true;
				}
			}

			//// we have a pair we can evaluate
			//if (resp != null) {
			//
			//	if (cond.Eval ()) {
			//
			///		resp.Execute ();
			//		rval = true;
			//	}
			//}
		}

		return rval;
	}
}
