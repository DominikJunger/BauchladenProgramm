using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BauchladenProgramm.Connector
{
    sealed class Syntax
    {
        //Primitiv Typen
        public static readonly String BOOLEAN = "(true|false)",
                                      INTEGER = @"-?(0|([1-9]\d{0,9}))",
                                      STRING = @"(?<=:).*",
                                      LONG = @"-?(0|([1-9]\d{0,18}))",
                                      CUT = @".*\r\n",
                                      CUTCELL = "begin:cell",
                                      CUTCELLS = "begin:cells";

        // seperators 
        public static readonly String[] SEPERATORS = { "\r\n", "\0" };

        // Characters
        public static readonly Char SPACE_CHAR = (char)32,
                                  LINE_BREAK_CHAR = (char)10,
                                  TAB_CHAR = (char)9,
                                  ESCAPE_CHAR = (char)27,
                                  COLON_CHAR = ':',
                                  ENUM_CHAR = ',',
                                  DOT_CHAR = '.',
                                  UNDERSCORE_CHAR = '_'
                                  ;

        // Strings
        // -> Keys
        public static readonly String BEGIN = "begin",
                                   END = "end",
                                   VERSION = "ver",
                                   ROUND = "round",
                                   RUNNING = "running",
                                   DELAY = "delay",
                                   ID = "id",
                                   DECISION = "decision",
                                   POINTS = "points",
                                   TOTAL = "total",
                                   TYPE = "type",
                                   ACCEPTED = "accepted",
                                   BUSY = "busy",
                                   DESCRIPTION = "desc",
                                   POS_X = "x",
                                   POS_Y = "y",
                                   ROW = "row",
                                   COL = "col",
                                   WIDTH = "width",
                                   HEIGHT = "height",
                                   SRCID = "srcid",
                                   SRC = "src",
                                   TEXT = "txt",
                                   ANSWER = "ans"
                                   ;
        public static String[] KEYS = {BEGIN, END, VERSION, ROUND, RUNNING,
                                    DELAY, ID, DECISION, POINTS, TOTAL, TYPE,
                                    ACCEPTED, BUSY, DESCRIPTION, POS_X, POS_Y,
                                    ROW, COL, WIDTH, HEIGHT, SRCID, SRC, 
                                    TEXT, ANSWER};

        // -> Values 
        public static readonly String UPDATE = "upd",
                                   SERVER = "server",
                                   RESULT = "result",
                                   PLAYERS = "players",
                                   PLAYER = "player",
                                   OPPONENT = "opponent",
                                   PLAYER_TYPE = "Player",
                                   CHALLENGE = "challenge",
                                   DRAGON = "dragon",
                                   DRAGON_TYPE = "Dragon",
                                   ENTITIES = "ents",
                                   CELL = "cell",
                                   MAPCELL = "mapcell", // only interesting for interpreting 
                                   FIELDTYPE = "fieldType",
                                   CELLS = "cells",
                                   PROPERTIES = "props",
                                   MAP = "map",
                                   MESSAGE = "mes",
                                   DELETE = "del",
                                   OKAY = "ok",
                                   DENY = "no",
                                   UNKNOWN = "unknown",
                                   INVALID = "invalid",
                                   YOURID = "yourid",
                                   TIME = "time",
                                   ONLINE = "online",
                                   HUNTABLE = "HUNTABLE",
                                   WALKABLE = "WALKABLE",
                                   WALL = "WALL",
                                   FOREST = "FOREST",
                                   WATER = "WATER",
                                   FIGHT = "FIGHT",
                                   REST = "REST",
                                   STAG = "STAG",
                                   BUNNY = "BUNNY",
                                   SWORD = "SWORD",
                                   ALCHEMY = "ALCHEMY",
                                   MAGIC = "MAGIC",
                                   FIRSTPLAYER = "firstPlayer",
                                   SECONDPLAYER = "secondPlayer"
                                   ;

        public static String[] VALUES = { UPDATE, SERVER, RESULT, PLAYERS, PLAYER, OPPONENT,
                                       PLAYER_TYPE, CHALLENGE, DRAGON, DRAGON_TYPE,
                                       ENTITIES, CELL, CELLS, PROPERTIES, MAP,
                                       MESSAGE, DELETE, OKAY, DENY, UNKNOWN, INVALID,
                                       YOURID, TIME, ONLINE};


    }
}
