async function PerformCallback(name, args) {
    var result = await fetch("/", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Callback": name + ";" + args
        }
    })

    const textResponse = await result.text();

    console.log(textResponse)

    if (textResponse.split(":")[0] == "REDIR") {
        window.open(textResponse.split(":")[1].replace("DP_", ":"), "_self");
    }

    if (textResponse.split(":")[0] == "ALERT") {
        alert(textResponse.split(":")[1].replace("DP_", ":"));
    }

    if (textResponse.split(":")[0] == "POPUP") { 
        window.open(textResponse.split(":")[1].replace("DP_", ":"), textResponse.split(":")[2].replace("DP_", ":"), textResponse.split(":")[3].replace("DP_", ":"))
    }

    if (textResponse.split(":")[0] == "DATA") {
        return textResponse.split(":")[1].replace("DP_", ":");
    }


}