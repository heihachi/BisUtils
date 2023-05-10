//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/ryannkelly/Desktop/BisUtils/BisUtils.Generated/BisUtils.Generated.EnScript/EnScriptLexer.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace BisUtils.Generated.EnScript;
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public partial class EnScriptLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SINGLE_LINE_COMMENT=1, EMPTY_DELIMITED_COMMENT=2, DELIMITED_COMMENT=3, 
		WHITESPACES=4, CLASS=5, ENUM=6, SWITCH=7, EXTENDS=8, CONST=9, BREAK=10, 
		CASE=11, ELSE=12, FOR=13, CONTINUE=14, FOREACH=15, IF=16, NEW=17, RETURN=18, 
		THIS=19, THREAD=20, VOID=21, WHILE=22, AUTOPTR=23, AUTO=24, REF=25, NULL=26, 
		NOTNULL=27, NATIVE=28, VOLATILE=29, PROTO=30, STATIC=31, OWNED=32, REFERENCE=33, 
		OUT=34, PROTECTED=35, EVENT=36, TYPEDEF=37, MODDED=38, OVERRIDE=39, SEALED=40, 
		INOUT=41, SUPER=42, POINTER=43, GOTO=44, PRIVATE=45, EXTERNAL=46, DELETE=47, 
		LOCAL=48, DEFAULT=49, Increment=50, Decrement=51, LShift_Assign=52, RShift_Assign=53, 
		Subtract_Assign=54, Add_Assign=55, Multiply_Assign=56, Divide_Assign=57, 
		Or_Assign=58, Xor_Assign=59, LessEqual=60, GreaterEqual=61, And_Assign=62, 
		Inequal=63, Equal=64, LogicalOr=65, LogicalAnd=66, BitwiseOr=67, BitwiseXor=68, 
		BitwiseAnd=69, BitwiseNot=70, Greater=71, Less=72, Assign=73, Subtract=74, 
		Add=75, Multiply=76, Divide=77, LParenthesis=78, RParenthesis=79, LCurly=80, 
		RCurly=81, Comma=82, Colon=83, Semicolon=84, LSBracket=85, RSBracket=86, 
		Dot=87, Bang=88, DoubleQuote=89, SingleQuote=90, Modulo=91, IDENTIFIER=92, 
		PREPROC_LINE=93, PREPROC_FILE=94, LiteralString=95, LiteralInteger=96, 
		LiteralFloat=97, LiteralBoolean=98;
	public const int
		COMMENTS_CHANNEL=2;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN", "COMMENTS_CHANNEL"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"SINGLE_LINE_COMMENT", "EMPTY_DELIMITED_COMMENT", "DELIMITED_COMMENT", 
		"WHITESPACES", "CLASS", "ENUM", "SWITCH", "EXTENDS", "CONST", "BREAK", 
		"CASE", "ELSE", "FOR", "CONTINUE", "FOREACH", "IF", "NEW", "RETURN", "THIS", 
		"THREAD", "VOID", "WHILE", "AUTOPTR", "AUTO", "REF", "NULL", "NOTNULL", 
		"NATIVE", "VOLATILE", "PROTO", "STATIC", "OWNED", "REFERENCE", "OUT", 
		"PROTECTED", "EVENT", "TYPEDEF", "MODDED", "OVERRIDE", "SEALED", "INOUT", 
		"SUPER", "POINTER", "GOTO", "PRIVATE", "EXTERNAL", "DELETE", "LOCAL", 
		"DEFAULT", "Increment", "Decrement", "LShift_Assign", "RShift_Assign", 
		"Subtract_Assign", "Add_Assign", "Multiply_Assign", "Divide_Assign", "Or_Assign", 
		"Xor_Assign", "LessEqual", "GreaterEqual", "And_Assign", "Inequal", "Equal", 
		"LogicalOr", "LogicalAnd", "BitwiseOr", "BitwiseXor", "BitwiseAnd", "BitwiseNot", 
		"Greater", "Less", "Assign", "Subtract", "Add", "Multiply", "Divide", 
		"LParenthesis", "RParenthesis", "LCurly", "RCurly", "Comma", "Colon", 
		"Semicolon", "LSBracket", "RSBracket", "Dot", "Bang", "DoubleQuote", "SingleQuote", 
		"Modulo", "IDENTIFIER", "PREPROC_LINE", "PREPROC_FILE", "LiteralString", 
		"LiteralInteger", "LiteralFloat", "LiteralBoolean", "EnforceEscapeSequence", 
		"Diget", "HEXADECIMAL", "Number", "DecimalNumber"
	};


	public EnScriptLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public EnScriptLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, null, "'class'", "'enum'", "'switch'", "'extends'", 
		"'const'", "'break'", "'case'", "'else'", "'for'", "'contine'", "'foreach'", 
		"'if'", "'new'", "'return'", "'this'", "'thread'", "'void'", "'while'", 
		"'autoptr'", "'auto'", "'ref'", "'null'", "'notnull'", "'native'", "'volatile'", 
		"'proto'", "'static'", "'owned'", "'reference'", "'out'", "'protected'", 
		"'event'", "'typedef'", "'modded'", "'override'", "'sealed'", "'inout'", 
		"'super'", "'pointer'", "'goto'", "'private'", "'external'", "'delete'", 
		"'local'", "'default'", "'++'", "'--'", "'<<='", "'>>='", "'-='", "'+='", 
		"'*='", "'/='", "'|='", "'^='", "'<='", "'>='", "'&='", "'!='", "'=='", 
		"'||'", "'&&'", "'|'", "'^'", "'&'", "'~'", "'>'", "'<'", "'='", "'-'", 
		"'+'", "'*'", "'/'", "'('", "')'", "'{'", "'}'", "','", "':'", "';'", 
		"'['", "']'", "'.'", "'!'", "'\"'", "'''", "'%'", null, "'__LINE__'", 
		"'__FILE__'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SINGLE_LINE_COMMENT", "EMPTY_DELIMITED_COMMENT", "DELIMITED_COMMENT", 
		"WHITESPACES", "CLASS", "ENUM", "SWITCH", "EXTENDS", "CONST", "BREAK", 
		"CASE", "ELSE", "FOR", "CONTINUE", "FOREACH", "IF", "NEW", "RETURN", "THIS", 
		"THREAD", "VOID", "WHILE", "AUTOPTR", "AUTO", "REF", "NULL", "NOTNULL", 
		"NATIVE", "VOLATILE", "PROTO", "STATIC", "OWNED", "REFERENCE", "OUT", 
		"PROTECTED", "EVENT", "TYPEDEF", "MODDED", "OVERRIDE", "SEALED", "INOUT", 
		"SUPER", "POINTER", "GOTO", "PRIVATE", "EXTERNAL", "DELETE", "LOCAL", 
		"DEFAULT", "Increment", "Decrement", "LShift_Assign", "RShift_Assign", 
		"Subtract_Assign", "Add_Assign", "Multiply_Assign", "Divide_Assign", "Or_Assign", 
		"Xor_Assign", "LessEqual", "GreaterEqual", "And_Assign", "Inequal", "Equal", 
		"LogicalOr", "LogicalAnd", "BitwiseOr", "BitwiseXor", "BitwiseAnd", "BitwiseNot", 
		"Greater", "Less", "Assign", "Subtract", "Add", "Multiply", "Divide", 
		"LParenthesis", "RParenthesis", "LCurly", "RCurly", "Comma", "Colon", 
		"Semicolon", "LSBracket", "RSBracket", "Dot", "Bang", "DoubleQuote", "SingleQuote", 
		"Modulo", "IDENTIFIER", "PREPROC_LINE", "PREPROC_FILE", "LiteralString", 
		"LiteralInteger", "LiteralFloat", "LiteralBoolean"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "EnScriptLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static EnScriptLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,98,729,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,2,58,7,58,2,59,7,59,2,60,7,60,2,61,7,61,2,62,7,62,2,63,
		7,63,2,64,7,64,2,65,7,65,2,66,7,66,2,67,7,67,2,68,7,68,2,69,7,69,2,70,
		7,70,2,71,7,71,2,72,7,72,2,73,7,73,2,74,7,74,2,75,7,75,2,76,7,76,2,77,
		7,77,2,78,7,78,2,79,7,79,2,80,7,80,2,81,7,81,2,82,7,82,2,83,7,83,2,84,
		7,84,2,85,7,85,2,86,7,86,2,87,7,87,2,88,7,88,2,89,7,89,2,90,7,90,2,91,
		7,91,2,92,7,92,2,93,7,93,2,94,7,94,2,95,7,95,2,96,7,96,2,97,7,97,2,98,
		7,98,2,99,7,99,2,100,7,100,2,101,7,101,2,102,7,102,1,0,1,0,1,0,1,0,5,0,
		212,8,0,10,0,12,0,215,9,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,226,
		8,1,1,1,1,1,1,2,1,2,1,2,1,2,5,2,234,8,2,10,2,12,2,237,9,2,1,2,1,2,1,2,
		1,2,1,2,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,
		6,1,6,1,6,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,8,1,8,1,8,
		1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,10,1,11,1,11,
		1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,13,1,13,1,13,1,13,1,13,1,13,1,13,
		1,13,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,15,1,15,1,15,1,16,1,16,
		1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,17,1,17,1,18,1,18,1,18,1,18,1,18,
		1,19,1,19,1,19,1,19,1,19,1,19,1,19,1,20,1,20,1,20,1,20,1,20,1,21,1,21,
		1,21,1,21,1,21,1,21,1,22,1,22,1,22,1,22,1,22,1,22,1,22,1,22,1,23,1,23,
		1,23,1,23,1,23,1,24,1,24,1,24,1,24,1,25,1,25,1,25,1,25,1,25,1,26,1,26,
		1,26,1,26,1,26,1,26,1,26,1,26,1,27,1,27,1,27,1,27,1,27,1,27,1,27,1,28,
		1,28,1,28,1,28,1,28,1,28,1,28,1,28,1,28,1,29,1,29,1,29,1,29,1,29,1,29,
		1,30,1,30,1,30,1,30,1,30,1,30,1,30,1,31,1,31,1,31,1,31,1,31,1,31,1,32,
		1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,32,1,33,1,33,1,33,1,33,1,34,
		1,34,1,34,1,34,1,34,1,34,1,34,1,34,1,34,1,34,1,35,1,35,1,35,1,35,1,35,
		1,35,1,36,1,36,1,36,1,36,1,36,1,36,1,36,1,36,1,37,1,37,1,37,1,37,1,37,
		1,37,1,37,1,38,1,38,1,38,1,38,1,38,1,38,1,38,1,38,1,38,1,39,1,39,1,39,
		1,39,1,39,1,39,1,39,1,40,1,40,1,40,1,40,1,40,1,40,1,41,1,41,1,41,1,41,
		1,41,1,41,1,42,1,42,1,42,1,42,1,42,1,42,1,42,1,42,1,43,1,43,1,43,1,43,
		1,43,1,44,1,44,1,44,1,44,1,44,1,44,1,44,1,44,1,45,1,45,1,45,1,45,1,45,
		1,45,1,45,1,45,1,45,1,46,1,46,1,46,1,46,1,46,1,46,1,46,1,47,1,47,1,47,
		1,47,1,47,1,47,1,48,1,48,1,48,1,48,1,48,1,48,1,48,1,48,1,49,1,49,1,49,
		1,50,1,50,1,50,1,51,1,51,1,51,1,51,1,52,1,52,1,52,1,52,1,53,1,53,1,53,
		1,54,1,54,1,54,1,55,1,55,1,55,1,56,1,56,1,56,1,57,1,57,1,57,1,58,1,58,
		1,58,1,59,1,59,1,59,1,60,1,60,1,60,1,61,1,61,1,61,1,62,1,62,1,62,1,63,
		1,63,1,63,1,64,1,64,1,64,1,65,1,65,1,65,1,66,1,66,1,67,1,67,1,68,1,68,
		1,69,1,69,1,70,1,70,1,71,1,71,1,72,1,72,1,73,1,73,1,74,1,74,1,75,1,75,
		1,76,1,76,1,77,1,77,1,78,1,78,1,79,1,79,1,80,1,80,1,81,1,81,1,82,1,82,
		1,83,1,83,1,84,1,84,1,85,1,85,1,86,1,86,1,87,1,87,1,88,1,88,1,89,1,89,
		1,90,1,90,1,91,1,91,5,91,647,8,91,10,91,12,91,650,9,91,1,92,1,92,1,92,
		1,92,1,92,1,92,1,92,1,92,1,92,1,93,1,93,1,93,1,93,1,93,1,93,1,93,1,93,
		1,93,1,94,1,94,1,94,5,94,673,8,94,10,94,12,94,676,9,94,1,94,1,94,1,95,
		1,95,3,95,682,8,95,1,96,1,96,1,97,1,97,1,97,1,97,1,97,1,97,1,97,1,97,1,
		97,3,97,695,8,97,1,98,1,98,1,98,1,98,1,98,1,98,3,98,703,8,98,1,99,1,99,
		1,100,1,100,1,100,1,100,4,100,711,8,100,11,100,12,100,712,1,101,3,101,
		716,8,101,1,101,4,101,719,8,101,11,101,12,101,720,1,102,1,102,1,102,4,
		102,726,8,102,11,102,12,102,727,2,235,674,0,103,1,1,3,2,5,3,7,4,9,5,11,
		6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,
		37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,
		61,31,63,32,65,33,67,34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,
		85,43,87,44,89,45,91,46,93,47,95,48,97,49,99,50,101,51,103,52,105,53,107,
		54,109,55,111,56,113,57,115,58,117,59,119,60,121,61,123,62,125,63,127,
		64,129,65,131,66,133,67,135,68,137,69,139,70,141,71,143,72,145,73,147,
		74,149,75,151,76,153,77,155,78,157,79,159,80,161,81,163,82,165,83,167,
		84,169,85,171,86,173,87,175,88,177,89,179,90,181,91,183,92,185,93,187,
		94,189,95,191,96,193,97,195,98,197,0,199,0,201,0,203,0,205,0,1,0,6,2,0,
		10,10,13,13,3,0,9,10,13,13,32,32,3,0,65,90,95,95,97,122,4,0,48,57,65,90,
		95,95,97,122,1,0,48,57,3,0,48,57,65,70,97,102,737,0,1,1,0,0,0,0,3,1,0,
		0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,
		1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,
		0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,
		1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,
		0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,
		1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,
		0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,
		1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,0,0,91,1,0,0,
		0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,0,0,101,1,0,0,0,0,
		103,1,0,0,0,0,105,1,0,0,0,0,107,1,0,0,0,0,109,1,0,0,0,0,111,1,0,0,0,0,
		113,1,0,0,0,0,115,1,0,0,0,0,117,1,0,0,0,0,119,1,0,0,0,0,121,1,0,0,0,0,
		123,1,0,0,0,0,125,1,0,0,0,0,127,1,0,0,0,0,129,1,0,0,0,0,131,1,0,0,0,0,
		133,1,0,0,0,0,135,1,0,0,0,0,137,1,0,0,0,0,139,1,0,0,0,0,141,1,0,0,0,0,
		143,1,0,0,0,0,145,1,0,0,0,0,147,1,0,0,0,0,149,1,0,0,0,0,151,1,0,0,0,0,
		153,1,0,0,0,0,155,1,0,0,0,0,157,1,0,0,0,0,159,1,0,0,0,0,161,1,0,0,0,0,
		163,1,0,0,0,0,165,1,0,0,0,0,167,1,0,0,0,0,169,1,0,0,0,0,171,1,0,0,0,0,
		173,1,0,0,0,0,175,1,0,0,0,0,177,1,0,0,0,0,179,1,0,0,0,0,181,1,0,0,0,0,
		183,1,0,0,0,0,185,1,0,0,0,0,187,1,0,0,0,0,189,1,0,0,0,0,191,1,0,0,0,0,
		193,1,0,0,0,0,195,1,0,0,0,1,207,1,0,0,0,3,225,1,0,0,0,5,229,1,0,0,0,7,
		243,1,0,0,0,9,247,1,0,0,0,11,253,1,0,0,0,13,258,1,0,0,0,15,265,1,0,0,0,
		17,273,1,0,0,0,19,279,1,0,0,0,21,285,1,0,0,0,23,290,1,0,0,0,25,295,1,0,
		0,0,27,299,1,0,0,0,29,307,1,0,0,0,31,315,1,0,0,0,33,318,1,0,0,0,35,322,
		1,0,0,0,37,329,1,0,0,0,39,334,1,0,0,0,41,341,1,0,0,0,43,346,1,0,0,0,45,
		352,1,0,0,0,47,360,1,0,0,0,49,365,1,0,0,0,51,369,1,0,0,0,53,374,1,0,0,
		0,55,382,1,0,0,0,57,389,1,0,0,0,59,398,1,0,0,0,61,404,1,0,0,0,63,411,1,
		0,0,0,65,417,1,0,0,0,67,427,1,0,0,0,69,431,1,0,0,0,71,441,1,0,0,0,73,447,
		1,0,0,0,75,455,1,0,0,0,77,462,1,0,0,0,79,471,1,0,0,0,81,478,1,0,0,0,83,
		484,1,0,0,0,85,490,1,0,0,0,87,498,1,0,0,0,89,503,1,0,0,0,91,511,1,0,0,
		0,93,520,1,0,0,0,95,527,1,0,0,0,97,533,1,0,0,0,99,541,1,0,0,0,101,544,
		1,0,0,0,103,547,1,0,0,0,105,551,1,0,0,0,107,555,1,0,0,0,109,558,1,0,0,
		0,111,561,1,0,0,0,113,564,1,0,0,0,115,567,1,0,0,0,117,570,1,0,0,0,119,
		573,1,0,0,0,121,576,1,0,0,0,123,579,1,0,0,0,125,582,1,0,0,0,127,585,1,
		0,0,0,129,588,1,0,0,0,131,591,1,0,0,0,133,594,1,0,0,0,135,596,1,0,0,0,
		137,598,1,0,0,0,139,600,1,0,0,0,141,602,1,0,0,0,143,604,1,0,0,0,145,606,
		1,0,0,0,147,608,1,0,0,0,149,610,1,0,0,0,151,612,1,0,0,0,153,614,1,0,0,
		0,155,616,1,0,0,0,157,618,1,0,0,0,159,620,1,0,0,0,161,622,1,0,0,0,163,
		624,1,0,0,0,165,626,1,0,0,0,167,628,1,0,0,0,169,630,1,0,0,0,171,632,1,
		0,0,0,173,634,1,0,0,0,175,636,1,0,0,0,177,638,1,0,0,0,179,640,1,0,0,0,
		181,642,1,0,0,0,183,644,1,0,0,0,185,651,1,0,0,0,187,660,1,0,0,0,189,669,
		1,0,0,0,191,681,1,0,0,0,193,683,1,0,0,0,195,694,1,0,0,0,197,702,1,0,0,
		0,199,704,1,0,0,0,201,706,1,0,0,0,203,715,1,0,0,0,205,722,1,0,0,0,207,
		208,5,47,0,0,208,209,5,47,0,0,209,213,1,0,0,0,210,212,8,0,0,0,211,210,
		1,0,0,0,212,215,1,0,0,0,213,211,1,0,0,0,213,214,1,0,0,0,214,216,1,0,0,
		0,215,213,1,0,0,0,216,217,6,0,0,0,217,2,1,0,0,0,218,219,5,47,0,0,219,220,
		5,42,0,0,220,226,5,47,0,0,221,222,5,47,0,0,222,223,5,42,0,0,223,224,5,
		42,0,0,224,226,5,47,0,0,225,218,1,0,0,0,225,221,1,0,0,0,226,227,1,0,0,
		0,227,228,6,1,0,0,228,4,1,0,0,0,229,230,5,47,0,0,230,231,5,42,0,0,231,
		235,1,0,0,0,232,234,9,0,0,0,233,232,1,0,0,0,234,237,1,0,0,0,235,236,1,
		0,0,0,235,233,1,0,0,0,236,238,1,0,0,0,237,235,1,0,0,0,238,239,5,42,0,0,
		239,240,5,47,0,0,240,241,1,0,0,0,241,242,6,2,0,0,242,6,1,0,0,0,243,244,
		7,1,0,0,244,245,1,0,0,0,245,246,6,3,1,0,246,8,1,0,0,0,247,248,5,99,0,0,
		248,249,5,108,0,0,249,250,5,97,0,0,250,251,5,115,0,0,251,252,5,115,0,0,
		252,10,1,0,0,0,253,254,5,101,0,0,254,255,5,110,0,0,255,256,5,117,0,0,256,
		257,5,109,0,0,257,12,1,0,0,0,258,259,5,115,0,0,259,260,5,119,0,0,260,261,
		5,105,0,0,261,262,5,116,0,0,262,263,5,99,0,0,263,264,5,104,0,0,264,14,
		1,0,0,0,265,266,5,101,0,0,266,267,5,120,0,0,267,268,5,116,0,0,268,269,
		5,101,0,0,269,270,5,110,0,0,270,271,5,100,0,0,271,272,5,115,0,0,272,16,
		1,0,0,0,273,274,5,99,0,0,274,275,5,111,0,0,275,276,5,110,0,0,276,277,5,
		115,0,0,277,278,5,116,0,0,278,18,1,0,0,0,279,280,5,98,0,0,280,281,5,114,
		0,0,281,282,5,101,0,0,282,283,5,97,0,0,283,284,5,107,0,0,284,20,1,0,0,
		0,285,286,5,99,0,0,286,287,5,97,0,0,287,288,5,115,0,0,288,289,5,101,0,
		0,289,22,1,0,0,0,290,291,5,101,0,0,291,292,5,108,0,0,292,293,5,115,0,0,
		293,294,5,101,0,0,294,24,1,0,0,0,295,296,5,102,0,0,296,297,5,111,0,0,297,
		298,5,114,0,0,298,26,1,0,0,0,299,300,5,99,0,0,300,301,5,111,0,0,301,302,
		5,110,0,0,302,303,5,116,0,0,303,304,5,105,0,0,304,305,5,110,0,0,305,306,
		5,101,0,0,306,28,1,0,0,0,307,308,5,102,0,0,308,309,5,111,0,0,309,310,5,
		114,0,0,310,311,5,101,0,0,311,312,5,97,0,0,312,313,5,99,0,0,313,314,5,
		104,0,0,314,30,1,0,0,0,315,316,5,105,0,0,316,317,5,102,0,0,317,32,1,0,
		0,0,318,319,5,110,0,0,319,320,5,101,0,0,320,321,5,119,0,0,321,34,1,0,0,
		0,322,323,5,114,0,0,323,324,5,101,0,0,324,325,5,116,0,0,325,326,5,117,
		0,0,326,327,5,114,0,0,327,328,5,110,0,0,328,36,1,0,0,0,329,330,5,116,0,
		0,330,331,5,104,0,0,331,332,5,105,0,0,332,333,5,115,0,0,333,38,1,0,0,0,
		334,335,5,116,0,0,335,336,5,104,0,0,336,337,5,114,0,0,337,338,5,101,0,
		0,338,339,5,97,0,0,339,340,5,100,0,0,340,40,1,0,0,0,341,342,5,118,0,0,
		342,343,5,111,0,0,343,344,5,105,0,0,344,345,5,100,0,0,345,42,1,0,0,0,346,
		347,5,119,0,0,347,348,5,104,0,0,348,349,5,105,0,0,349,350,5,108,0,0,350,
		351,5,101,0,0,351,44,1,0,0,0,352,353,5,97,0,0,353,354,5,117,0,0,354,355,
		5,116,0,0,355,356,5,111,0,0,356,357,5,112,0,0,357,358,5,116,0,0,358,359,
		5,114,0,0,359,46,1,0,0,0,360,361,5,97,0,0,361,362,5,117,0,0,362,363,5,
		116,0,0,363,364,5,111,0,0,364,48,1,0,0,0,365,366,5,114,0,0,366,367,5,101,
		0,0,367,368,5,102,0,0,368,50,1,0,0,0,369,370,5,110,0,0,370,371,5,117,0,
		0,371,372,5,108,0,0,372,373,5,108,0,0,373,52,1,0,0,0,374,375,5,110,0,0,
		375,376,5,111,0,0,376,377,5,116,0,0,377,378,5,110,0,0,378,379,5,117,0,
		0,379,380,5,108,0,0,380,381,5,108,0,0,381,54,1,0,0,0,382,383,5,110,0,0,
		383,384,5,97,0,0,384,385,5,116,0,0,385,386,5,105,0,0,386,387,5,118,0,0,
		387,388,5,101,0,0,388,56,1,0,0,0,389,390,5,118,0,0,390,391,5,111,0,0,391,
		392,5,108,0,0,392,393,5,97,0,0,393,394,5,116,0,0,394,395,5,105,0,0,395,
		396,5,108,0,0,396,397,5,101,0,0,397,58,1,0,0,0,398,399,5,112,0,0,399,400,
		5,114,0,0,400,401,5,111,0,0,401,402,5,116,0,0,402,403,5,111,0,0,403,60,
		1,0,0,0,404,405,5,115,0,0,405,406,5,116,0,0,406,407,5,97,0,0,407,408,5,
		116,0,0,408,409,5,105,0,0,409,410,5,99,0,0,410,62,1,0,0,0,411,412,5,111,
		0,0,412,413,5,119,0,0,413,414,5,110,0,0,414,415,5,101,0,0,415,416,5,100,
		0,0,416,64,1,0,0,0,417,418,5,114,0,0,418,419,5,101,0,0,419,420,5,102,0,
		0,420,421,5,101,0,0,421,422,5,114,0,0,422,423,5,101,0,0,423,424,5,110,
		0,0,424,425,5,99,0,0,425,426,5,101,0,0,426,66,1,0,0,0,427,428,5,111,0,
		0,428,429,5,117,0,0,429,430,5,116,0,0,430,68,1,0,0,0,431,432,5,112,0,0,
		432,433,5,114,0,0,433,434,5,111,0,0,434,435,5,116,0,0,435,436,5,101,0,
		0,436,437,5,99,0,0,437,438,5,116,0,0,438,439,5,101,0,0,439,440,5,100,0,
		0,440,70,1,0,0,0,441,442,5,101,0,0,442,443,5,118,0,0,443,444,5,101,0,0,
		444,445,5,110,0,0,445,446,5,116,0,0,446,72,1,0,0,0,447,448,5,116,0,0,448,
		449,5,121,0,0,449,450,5,112,0,0,450,451,5,101,0,0,451,452,5,100,0,0,452,
		453,5,101,0,0,453,454,5,102,0,0,454,74,1,0,0,0,455,456,5,109,0,0,456,457,
		5,111,0,0,457,458,5,100,0,0,458,459,5,100,0,0,459,460,5,101,0,0,460,461,
		5,100,0,0,461,76,1,0,0,0,462,463,5,111,0,0,463,464,5,118,0,0,464,465,5,
		101,0,0,465,466,5,114,0,0,466,467,5,114,0,0,467,468,5,105,0,0,468,469,
		5,100,0,0,469,470,5,101,0,0,470,78,1,0,0,0,471,472,5,115,0,0,472,473,5,
		101,0,0,473,474,5,97,0,0,474,475,5,108,0,0,475,476,5,101,0,0,476,477,5,
		100,0,0,477,80,1,0,0,0,478,479,5,105,0,0,479,480,5,110,0,0,480,481,5,111,
		0,0,481,482,5,117,0,0,482,483,5,116,0,0,483,82,1,0,0,0,484,485,5,115,0,
		0,485,486,5,117,0,0,486,487,5,112,0,0,487,488,5,101,0,0,488,489,5,114,
		0,0,489,84,1,0,0,0,490,491,5,112,0,0,491,492,5,111,0,0,492,493,5,105,0,
		0,493,494,5,110,0,0,494,495,5,116,0,0,495,496,5,101,0,0,496,497,5,114,
		0,0,497,86,1,0,0,0,498,499,5,103,0,0,499,500,5,111,0,0,500,501,5,116,0,
		0,501,502,5,111,0,0,502,88,1,0,0,0,503,504,5,112,0,0,504,505,5,114,0,0,
		505,506,5,105,0,0,506,507,5,118,0,0,507,508,5,97,0,0,508,509,5,116,0,0,
		509,510,5,101,0,0,510,90,1,0,0,0,511,512,5,101,0,0,512,513,5,120,0,0,513,
		514,5,116,0,0,514,515,5,101,0,0,515,516,5,114,0,0,516,517,5,110,0,0,517,
		518,5,97,0,0,518,519,5,108,0,0,519,92,1,0,0,0,520,521,5,100,0,0,521,522,
		5,101,0,0,522,523,5,108,0,0,523,524,5,101,0,0,524,525,5,116,0,0,525,526,
		5,101,0,0,526,94,1,0,0,0,527,528,5,108,0,0,528,529,5,111,0,0,529,530,5,
		99,0,0,530,531,5,97,0,0,531,532,5,108,0,0,532,96,1,0,0,0,533,534,5,100,
		0,0,534,535,5,101,0,0,535,536,5,102,0,0,536,537,5,97,0,0,537,538,5,117,
		0,0,538,539,5,108,0,0,539,540,5,116,0,0,540,98,1,0,0,0,541,542,5,43,0,
		0,542,543,5,43,0,0,543,100,1,0,0,0,544,545,5,45,0,0,545,546,5,45,0,0,546,
		102,1,0,0,0,547,548,5,60,0,0,548,549,5,60,0,0,549,550,5,61,0,0,550,104,
		1,0,0,0,551,552,5,62,0,0,552,553,5,62,0,0,553,554,5,61,0,0,554,106,1,0,
		0,0,555,556,5,45,0,0,556,557,5,61,0,0,557,108,1,0,0,0,558,559,5,43,0,0,
		559,560,5,61,0,0,560,110,1,0,0,0,561,562,5,42,0,0,562,563,5,61,0,0,563,
		112,1,0,0,0,564,565,5,47,0,0,565,566,5,61,0,0,566,114,1,0,0,0,567,568,
		5,124,0,0,568,569,5,61,0,0,569,116,1,0,0,0,570,571,5,94,0,0,571,572,5,
		61,0,0,572,118,1,0,0,0,573,574,5,60,0,0,574,575,5,61,0,0,575,120,1,0,0,
		0,576,577,5,62,0,0,577,578,5,61,0,0,578,122,1,0,0,0,579,580,5,38,0,0,580,
		581,5,61,0,0,581,124,1,0,0,0,582,583,5,33,0,0,583,584,5,61,0,0,584,126,
		1,0,0,0,585,586,5,61,0,0,586,587,5,61,0,0,587,128,1,0,0,0,588,589,5,124,
		0,0,589,590,5,124,0,0,590,130,1,0,0,0,591,592,5,38,0,0,592,593,5,38,0,
		0,593,132,1,0,0,0,594,595,5,124,0,0,595,134,1,0,0,0,596,597,5,94,0,0,597,
		136,1,0,0,0,598,599,5,38,0,0,599,138,1,0,0,0,600,601,5,126,0,0,601,140,
		1,0,0,0,602,603,5,62,0,0,603,142,1,0,0,0,604,605,5,60,0,0,605,144,1,0,
		0,0,606,607,5,61,0,0,607,146,1,0,0,0,608,609,5,45,0,0,609,148,1,0,0,0,
		610,611,5,43,0,0,611,150,1,0,0,0,612,613,5,42,0,0,613,152,1,0,0,0,614,
		615,5,47,0,0,615,154,1,0,0,0,616,617,5,40,0,0,617,156,1,0,0,0,618,619,
		5,41,0,0,619,158,1,0,0,0,620,621,5,123,0,0,621,160,1,0,0,0,622,623,5,125,
		0,0,623,162,1,0,0,0,624,625,5,44,0,0,625,164,1,0,0,0,626,627,5,58,0,0,
		627,166,1,0,0,0,628,629,5,59,0,0,629,168,1,0,0,0,630,631,5,91,0,0,631,
		170,1,0,0,0,632,633,5,93,0,0,633,172,1,0,0,0,634,635,5,46,0,0,635,174,
		1,0,0,0,636,637,5,33,0,0,637,176,1,0,0,0,638,639,5,34,0,0,639,178,1,0,
		0,0,640,641,5,39,0,0,641,180,1,0,0,0,642,643,5,37,0,0,643,182,1,0,0,0,
		644,648,7,2,0,0,645,647,7,3,0,0,646,645,1,0,0,0,647,650,1,0,0,0,648,646,
		1,0,0,0,648,649,1,0,0,0,649,184,1,0,0,0,650,648,1,0,0,0,651,652,5,95,0,
		0,652,653,5,95,0,0,653,654,5,76,0,0,654,655,5,73,0,0,655,656,5,78,0,0,
		656,657,5,69,0,0,657,658,5,95,0,0,658,659,5,95,0,0,659,186,1,0,0,0,660,
		661,5,95,0,0,661,662,5,95,0,0,662,663,5,70,0,0,663,664,5,73,0,0,664,665,
		5,76,0,0,665,666,5,69,0,0,666,667,5,95,0,0,667,668,5,95,0,0,668,188,1,
		0,0,0,669,674,5,34,0,0,670,673,3,197,98,0,671,673,9,0,0,0,672,670,1,0,
		0,0,672,671,1,0,0,0,673,676,1,0,0,0,674,675,1,0,0,0,674,672,1,0,0,0,675,
		677,1,0,0,0,676,674,1,0,0,0,677,678,5,34,0,0,678,190,1,0,0,0,679,682,3,
		203,101,0,680,682,3,201,100,0,681,679,1,0,0,0,681,680,1,0,0,0,682,192,
		1,0,0,0,683,684,3,205,102,0,684,194,1,0,0,0,685,686,5,116,0,0,686,687,
		5,114,0,0,687,688,5,117,0,0,688,695,5,101,0,0,689,690,5,102,0,0,690,691,
		5,97,0,0,691,692,5,108,0,0,692,693,5,115,0,0,693,695,5,101,0,0,694,685,
		1,0,0,0,694,689,1,0,0,0,695,196,1,0,0,0,696,697,5,92,0,0,697,703,5,92,
		0,0,698,699,5,92,0,0,699,703,5,34,0,0,700,701,5,92,0,0,701,703,5,39,0,
		0,702,696,1,0,0,0,702,698,1,0,0,0,702,700,1,0,0,0,703,198,1,0,0,0,704,
		705,7,4,0,0,705,200,1,0,0,0,706,707,5,48,0,0,707,708,5,120,0,0,708,710,
		1,0,0,0,709,711,7,5,0,0,710,709,1,0,0,0,711,712,1,0,0,0,712,710,1,0,0,
		0,712,713,1,0,0,0,713,202,1,0,0,0,714,716,5,45,0,0,715,714,1,0,0,0,715,
		716,1,0,0,0,716,718,1,0,0,0,717,719,3,199,99,0,718,717,1,0,0,0,719,720,
		1,0,0,0,720,718,1,0,0,0,720,721,1,0,0,0,721,204,1,0,0,0,722,723,3,203,
		101,0,723,725,5,46,0,0,724,726,3,199,99,0,725,724,1,0,0,0,726,727,1,0,
		0,0,727,725,1,0,0,0,727,728,1,0,0,0,728,206,1,0,0,0,14,0,213,225,235,648,
		672,674,681,694,702,712,715,720,727,2,0,2,0,0,1,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}