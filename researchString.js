// there is other js in 'webSites/index.html'

//this is the map where the program put the char as key and the number of char in the string is the value
let hashStringa = new Map();
let hashArray = new Map();

//es: jack --> [[j,1],[a,1],[c,1],[k,1]]

//this is the function you must copy for searc a string
function search() {

    hashStringa.clear();
    hashArray.clear()

    document.getElementById("similar").innerHTML = '';

    let stringa = document.getElementById("search").value;  //this is the variable to search in the array

    console.log(stringa);

    mappingString(1, stringa);

    for (let i = 0; i < array.length; i++) {
        mappingString(0, array[i]);

        //punteggio in italian is point
        let punteggio = 0;

        //dare il punteggio

        for (let x = 0; x < hashStringa.size; x++) {


        }

        hashStringa.forEach((value, key, char) => {
            if (hashArray.has(key) == true) {
                punteggio++;
                if (value == hashArray.get(key)) {
                    punteggio += 3;
                }
            }
        });

        //median of punteggio
        punteggio /= hashStringa.size;

        if (punteggio >= 3) {
            document.getElementById("similar").innerHTML += '<li>' + array[i] + '</li>';
        }

        console.log(punteggio);

        hashArray.clear();
    }
}

function mappingString(num, stringa) {
    //this is an array for separete the char of the 'stringa'
    let arrayChar = [];

    let key;
    let value = 0;

    for (let i = 0; i < stringa.length; i++) {
        if (!arrayChar.includes(stringa[i])) {
            arrayChar.push(stringa[i]);

            key = stringa[i];

            console.log(key); // Mostra il nuovo carattere unico

            for (x = 0; x < stringa.length; x++) {
                if (key === stringa[x]) {
                    value++;
                }
            }

            console.log(value);

            if (num == 1) {
                hashStringa.set(key, value);
            }
            else {
                hashArray.set(key, value);
            }

            value = 0;
        }
    }
}