module BowlingLib

let addUp throws = Seq.sum throws

let scoreThrows (throws: #seq<int>) = 
    addUp throws

let scoreCurrentFrame throws =
    match throws with 
    |a::b::tl when (a = 10)  ->
        let c = List.head tl
        ((a+b+c), b::tl)
    |a::b::tl when (a + b = 10) ->
        let c = List.head tl
        ((a+b+c), tl)
    |a::b::tl ->
        ((a+b), tl)
    |a::tl -> (a, [])
    |[] -> (0, [])

let rec scoreGameUtil currentScore throws frameNum= 
    match (frameNum, throws) with 
    |(_,[]) -> currentScore
    |(10,_) -> currentScore
    |_ -> 
        let (currentFrame, remainingThrows) = scoreCurrentFrame throws
        scoreGameUtil (currentScore + currentFrame) remainingThrows (frameNum + 1)
        
let scoreGame throws = scoreGameUtil 0 throws 0


        
        
        
        
       

