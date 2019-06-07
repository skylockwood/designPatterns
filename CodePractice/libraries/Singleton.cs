using System;
using System.Collections.Generic;


namespace CodePractice{
    class LoadBalancer{
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();
        private static object padlock = new object();

        protected LoadBalancer(){
            _servers.Add("ServerI");
            _servers.Add("ServersII");
            _servers.Add("ServersIII");
            _servers.Add("ServersIV");
            _servers.Add("ServersV");
        }

        public String Server{
            get{
                return _servers[_random.Next(_servers.Count)].ToString();
            }
        }

        public static LoadBalancer GetLoadBalancer(){
            if(_instance == null){
                lock(padlock){
                    if(_instance == null){
                        _instance = new LoadBalancer();
                    }
                }
            }
            return _instance;
        }
    }
}
