using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST_WCF_MED_DB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //HTTP
        //Get all
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "games")
        ]
        List<Game> GetGame();


        //Get by id
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "games/{id}")
        ]
        Game GetOneGame(string id);

        //Post/create
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                //ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "games")
        ]
        void AddGame(Game newGame);

        //Delete
        [WebInvoke(
                Method = "DELETE",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "games?id={id}")
        ]
        void Deletegame(string id);

        //Update/Put
        [WebInvoke(
                Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "games")
        ]
        void UpdateMovie(Game myGame);
    }


    
}
