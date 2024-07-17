using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 解释器 设计模式
    /// Context，上下文
    /// IExpression，表达式接口
    /// 终结符表达式，Contain，等等
    /// 非终结符表达式，And，Or
    /// 要点：表达式对象化=终结符表达式+非终结符表达式
    /// 
    /// 行为:转译(一个上下文,多种转译语法)
    /// 
    /// </summary>
    public class SampleInterpreter
    {
        public void Test()
        {
            var context1 = new Context { Input = "hello world!" };
            Expression expression1 = new ContainExpression("hello");
            Expression expression2 = new ContainExpression("good");
            Expression expressionOr = new OrExpression(expression1, expression2);
            Expression expressionAnd = new AndExpression(expression1, expression2);
            Console.WriteLine(expressionOr.Interpret(context1));
            Console.WriteLine(expressionAnd.Interpret(context1));
        }
    }

    public class Context
    {
        public string Input { set; get; }
        public string Output { set; get; }
    }

    public abstract class Expression
    {
        public abstract bool Interpret(Context context);
    }

    /// <summary>
    /// Terminal 
    /// </summary>
    public class ContainExpression : Expression
    {
        string _data;
        public ContainExpression(string data)
        {
            _data = data;
        }

        public override bool Interpret(Context context)
        {
            return context.Input.Contains(_data);
        }
    }
    /// <summary>
    /// Non-terminal
    /// </summary>
    public class OrExpression : Expression
    {
        Expression _expr1;
        Expression _expr2;

        public OrExpression(Expression expr1, Expression expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
        }

        public override bool Interpret(Context context)
        {
            return _expr1.Interpret(context) || _expr2.Interpret(context);
        }
    }
    public class AndExpression : Expression
    {
        Expression _expr1;
        Expression _expr2;

        public AndExpression(Expression expr1, Expression expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
        }

        public override bool Interpret(Context context)
        {
            return _expr1.Interpret(context) && _expr2.Interpret(context);
        }
    }
}