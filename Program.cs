using System;

/*
 Z13. Вы открыли свое брачное агентство и к текущему моменту наработали хорошую базу мужчин и женщин, желающих найти себе будущего супруга. 
 Проанализировав все анкеты, вы определили множество взаимных симпатий. При этом одному субъекту может «взаимно симпатизировать» несколько объектов противоположного пола.
  Наконец, вырешили организовать вечер свиданий для своих клиентов. Решите этот вопрос таким образом, чтобы на вечере состоялось максимально возможное количество свиданий.
 */
    //неориентированный граф
namespace Semestrovka
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            for (int i = 0; i < 9; i++)
            {
                graph.AddNodeById(i);
            }
            graph.nodes[0].Connect(graph.nodes[1]);
            graph.nodes[0].Connect(graph.nodes[4]);
            graph.nodes[1].Connect(graph.nodes[2]);
            graph.nodes[1].Connect(graph.nodes[5]);
            graph.nodes[1].Connect(graph.nodes[4]);
            graph.nodes[2].Connect(graph.nodes[3]);
            graph.nodes[2].Connect(graph.nodes[5]);
            graph.nodes[2].Connect(graph.nodes[6]);
            graph.nodes[4].Connect(graph.nodes[5]);
            graph.nodes[4].Connect(graph.nodes[7]);
            graph.nodes[5].Connect(graph.nodes[8]);
            graph.nodes[5].Connect(graph.nodes[7]);
            graph.nodes[7].Connect(graph.nodes[8]);
            graph.nodes[8].Connect(graph.nodes[6]);
            
            foreach (var node in graph.nodes)
            {
                Console.WriteLine(node.ToString());
            }
            graph.GetPairs();
        }
    }
}
