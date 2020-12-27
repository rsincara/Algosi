using System;

/*
 Z13. Вы открыли свое брачное агентство и к текущему моменту наработали хорошую базу мужчин и женщин, желающих найти себе будущего супруга. 
 Проанализировав все анкеты, вы определили множество взаимных симпатий. При этом одному субъекту может «взаимно симпатизировать» несколько объектов противоположного пола.
  Наконец, вырешили организовать вечер свиданий для своих клиентов. Решите этот вопрос таким образом, чтобы на вечере состоялось максимально возможное количество свиданий.
 */
namespace Semestrovka    
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            for (int i = 0; i <= 8; i++)
            {
                graph.AddNodeById(i);
            }
            graph.ConnectNodesById(0,1);
            graph.ConnectNodesById(0,4);
            graph.ConnectNodesById(1,2);
            graph.ConnectNodesById(1,5);
            graph.ConnectNodesById(1,4);
            graph.ConnectNodesById(2,3);
            graph.ConnectNodesById(2,5);
            graph.ConnectNodesById(2,6);
            graph.ConnectNodesById(4,5);
            graph.ConnectNodesById(4,7);
            graph.ConnectNodesById(5,8);
            graph.ConnectNodesById(5,7);
            graph.ConnectNodesById(7,8);
            graph.ConnectNodesById(6,8);
            
          
           
         
            
            foreach (var node in graph.nodes)
            {
                Console.WriteLine(node.ToString());
            }
            graph.GetPairs();
        }
    }
}
