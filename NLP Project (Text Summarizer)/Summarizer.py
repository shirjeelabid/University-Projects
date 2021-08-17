import networkx as nx
import numpy as np
import nltk
from nltk.cluster.util import cosine_distance
from nltk.corpus import stopwords




def sentence_cleaning(file_name):
    file = open(file_name, "r")
    filedata = file.readlines()
    article = filedata[0].split(". ")
    sentences = []

    for sentence in article:
        print(sentence)
        sentences.append(sentence.replace("[^a-zA-Z]", " ").split(" "))
    sentences.pop() 
    
    return sentences

def sentence_similarity(sent1, sent2, stopwords=None):
    if stopwords is None:
        stopwords = []
 
    sent1 = [w.lower() for w in sent1]
    sent2 = [w.lower() for w in sent2]
 
    all_words = list(set(sent1 + sent2))
 
    vector1 = [0] * len(all_words)
    vector2 = [0] * len(all_words)
 
    for temp1 in sent1:
        if temp1 in stopwords:
            continue
        vector1[all_words.index(temp1)] += 1
 
    for temp2 in sent2:
        if temp2 in stopwords:
            continue
        vector2[all_words.index(temp2)] += 1
 
    return 1 - cosine_distance(vector1, vector2)
 
def similarity_matrix_creation(sentences, stop_words):
    
    similarity_matrix = np.zeros((len(sentences), len(sentences)))
 
    for idx1 in range(len(sentences)):
        for idx2 in range(len(sentences)):
            if idx1 == idx2: 
                continue 
            similarity_matrix[idx1][idx2] = sentence_similarity(sentences[idx1], sentences[idx2], stop_words)

    return similarity_matrix


def generate_SummarizedText(file_name, top_n=5):
    nltk.download("stopwords")
    stop_words = stopwords.words('english')
    summarize_text = []

    sentences =  sentence_cleaning(file_name)

    sentence_similarity_martix = similarity_matrix_creation(sentences, stop_words)

    sentence_similarity_graph = nx.from_numpy_array(sentence_similarity_martix)
    scores = nx.pagerank(sentence_similarity_graph)

    ranked_sentence = sorted(((scores[i],s) for i,s in enumerate(sentences)), reverse=True)    
    print("Indexes of top ranked sentence order is:  ", ranked_sentence)    

    for i in range(top_n):
      summarize_text.append(" ".join(ranked_sentence[i][1]))

    print("Summarized Text: \n", ". ".join(summarize_text))

generate_SummarizedText( "original.txt", 2)