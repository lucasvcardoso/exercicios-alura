$("#cipher").on("input", function(char){
    $("#cifra").val(cipher($("#cipher").val()), false);        
});

function cipher(val, decode){

    var map = [
        'a', 
        'b',
        'c', 
        'd', 
        'e',
        'f', 
        'g', 
        'h',
        'i', 
        'j', 
        'k',
        'l', 
        'm', 
        'n',
        'o', 
        'p', 
        'q',
        'r', 
        's', 
        't',
        'u', 
        'v', 
        'w',
        'x', 
        'y',
        'z'       
    ];
     
    var result = "";
    var posicao = 0;
    if(decode){
        for(var i = 0; i < val.length; i++){
            if(map.indexOf(val.split("")[i] > -1)){            
                result += map[map.indexOf(val.split('')[i])-2].toUpperCase();
            }else{
                result = result;
            }
        }
    }else{
        for(var i = 0; i < val.length; i++){
            if(map.indexOf(val.split("")[i] > -1 && !(map.indexOf(val.split("")[i] == map.length -1)))){   
                posicao = map.indexOf(val.split('')[i])+2;         
                if(posicao < map.length && posicao > -1){
                    result += map[posicao];
                }else if (posicao >= map.length){
                    posicao = posicao - 26;
                    result += map[posicao];
                }else if(posicao < 0){
                    posicao += 26;
                    result += map[posicao];
                }
            }else if(map.indexOf(val.split("")[i] == " ")){
                    result += " ";
            }else{
                result = result;
            }
        }
    }   
    return result;


}

