namespace BowlingTests

open BowlingLib
open NUnit.Framework

[<TestFixture>]
module public BowlingTests = 
    
    [<Test>]
    let trueIsTrue() = 
        Assert.AreEqual(true, true)

    [<Test>]
    let scoreNoThrowsIsZero() = 
        let score = scoreThrows []
        Assert.AreEqual(0,score)

    [<Test>]
    let scoreOneIsOne () = 
        let score = scoreThrows [1]
        Assert.AreEqual(1,score)

    [<Test>]
    let scoreTenIsTen () = 
        let score = scoreThrows [1;9]
        Assert.AreEqual(10,score)

    [<Test>]
    let scoreSpareInCurrentFrameIncludesTenPlusOneMoreThrow() = 
        let (score, _) = scoreCurrentFrame [1;9;5]
        Assert.AreEqual(15,score)

    [<Test>]
    let scoreStrikeInCurrentFrameIncludesTenPlusOneMoreThrow() = 
        let (score, _) = scoreCurrentFrame [10;9;5]
        Assert.AreEqual(24,score)
    [<Test>]
    let scoreThreeStrikesInARowGives30ForCurrentFrame() = 
        let (score, _) = scoreCurrentFrame [10;10;10]
        Assert.AreEqual(30,score)

    [<Test>]
    let scoreNonSparingFrameGivesRemainderOfInputLessFirstTwoBalls() =
        let (score, remainingBalls) = scoreCurrentFrame [1;1;8]
        Assert.AreEqual(8, List.head remainingBalls)

    [<Test>]
    let scoreSparingFrameGivesRemainderOfInputLessFirstTwoBalls() =
        let (score, remainingBalls) = scoreCurrentFrame [1;9;8]
        Assert.AreEqual(8, List.head remainingBalls)

    [<Test>]
    let scoreStrikingFrameGivesRemainderOfInputLessFirstBall() =
        let (score, remainingBalls) = scoreCurrentFrame [10;9;8]
        Assert.AreEqual(9, List.head remainingBalls)

    [<Test>]
    let perfectGameEqual300() =
        let score = scoreGame [10;10;10;10;10;10;10;10;10;10;10;10] 
        Assert.AreEqual(300, score)

    [<Test>]
    let allSparesOf9And1WithLastBallOf9Scores190() = 
        let score =  
            scoreGame 
                [for i in 1..10 do 
                    yield 9; yield 1; 
                 yield 9]

        Assert.AreEqual(190,score)







