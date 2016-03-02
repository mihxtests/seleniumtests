Feature: sample
	webpage

@mytag
Scenario Outline: SearchResult
	Given I have open "http://google.com"
	And I have entered <searchText> into search
	When I press search
	Then The first result should start with <resultText>
	
	Examples:
	| searchText            | resultText                            |
	| "dupa"                | "Dupa - Nonsensopedia"                |
	| "kominek w domu plan" | "Projektowanie kominka krok po kroku" |